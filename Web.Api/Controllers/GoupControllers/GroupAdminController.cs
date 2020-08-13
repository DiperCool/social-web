using System;
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
using System.Linq;
using System.Collections.Generic;
using Web.Models.Models;

namespace Web.Api.Controllers.GoupControllers
{
    [ApiController]
    [Authorize]
    public class GroupAdminController:ControllerBase
    {
        IGroupsDbStore _context;
        IMapper _mapper;

        public GroupAdminController(IGroupsDbStore context)
        {
            _context = context;
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperConfig>();
            });
            _mapper=new Mapper(config);
        }

        [UserAdminGroupFilter(RightType.ChangeRightAdmin)]
        [HttpPost("/group/setRight")]
        public async Task<IActionResult> setAdmin([FromBody] RightModel model,string loginGroup, string loginUser)
        {
            if(await _context.userIsCreator(loginGroup, loginUser)||loginUser==User.Identity.Name)
            {
                return BadRequest("no rigth");
            }
            if(model.Rights.Count==0){
                
            }
            else if(await _context.userIsAdmin(loginGroup, loginUser))
            {
                await _context.changeAdminRights(loginGroup, loginUser, model.Rights);
            }
            else
            {
                await _context.setAdmin(loginGroup, loginUser,model.Rights );
            }
            return Ok();
        }

        [HttpGet("/group/getUserRigths")]
        public async Task<IActionResult> getRigths(string loginGroup, string loginUser)
        {
            var rigths=await _context.getRight(loginGroup, loginUser);
            return Ok(rigths);
        }

        [AllowAnonymous]
        [HttpGet("/group/getAdmins")]
        public IActionResult getAdmins(string loginGroup, int id){
            var res=_mapper.Map<List<AdminGroup>,List<AdminGroupDTO>>(_context.GetAdminGroups(loginGroup, 5, id));
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet("/group/userIsAdmin")]
        public async Task<IActionResult> isAdmin(string loginGroup, string loginUser){
            return Ok(await _context.userIsAdmin(loginGroup, loginUser));
        }
    }
}