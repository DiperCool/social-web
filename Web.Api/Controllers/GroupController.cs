using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Infrastructure.Filters;
using Web.Models.AutoMapperDTO;
using Web.Models.Configs.AutoMapper;
using Web.Models.Entity;
using Web.Models.Enums;
using Web.Models.Interfaces.Stores;

namespace Web.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        IGroupsDbStore _context;
        IPostDbStore _post;
        IMapper _mapper;

        public GroupController(IGroupsDbStore context, IPostDbStore post)
        {
            _context = context;
            _post=post;
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperConfig>();
            });
            _mapper=new Mapper(config);
        }

        [HttpPost("/group/create")]
        public async Task<IActionResult> createGroup(string name, string login)
        {
            if(await _context.loginIsExist(login))
            {
                return BadRequest("Login is exist");
            } 
            Group group= await _context.createGroup(login, name);
            await _context.setAdmin(group.Login,User.Identity.Name, RightType.Сreator);
            await _context.addToGroup(group.Login, User.Identity.Name);
            return Ok(_mapper.Map<Group, GroupDTO>(group));     
        }
        [TypeFilter(typeof(UserAdminGroupAttribute), Arguments= new object[]{RightType.Сreator})]
        [HttpPost("/group/setAdmin")]
        public async Task<IActionResult> setAdmin(string loginGroup, string loginUser)
        {
            if(!await _context.userIsSubscribed(loginUser, loginGroup))
            {
                return BadRequest("User not subscribed");
            }
            await _context.setAdmin(loginGroup, loginUser, RightType.Moderator);
            return Ok();
        }
    }
}