using System;
using System.Linq;
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
using Web.Models.Models;

namespace Web.Api.Controllers.GoupControllers
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
        public async Task<IActionResult> createGroup([FromBody] CreateGroup model)
        {
            if(!ModelState.IsValid) return BadRequest("model");
            string login= model.Login;
            string name= model.Name;
            if(await _context.loginIsExist(login))
            {
                return BadRequest("Login is exist");
            } 
            Group group= await _context.createGroup(login, name, User.Identity.Name);
            await _context.setAdmin(group.Login,User.Identity.Name, Enum.GetValues(typeof(RightType))
                                                                .OfType<RightType>()
                                                                .ToList());
            await _context.addToGroup(group.Login, User.Identity.Name);
            return Ok(_mapper.Map<Group, GroupDTO>(group));     
        }
        
        [HttpPost("/group/updateInfo")]
        [UserAdminGroupFilter(RightType.ChangeGroupInfo)]
        public async Task<IActionResult> updateInfo([FromBody] GroupInfoDTO model)
        {
            if(!ModelState.IsValid) return BadRequest(model);
            GroupInfo info= _mapper.Map<GroupInfoDTO, GroupInfo>(model);
            return Ok(await _context.changeGroupInfo(info));

        }

    }
}