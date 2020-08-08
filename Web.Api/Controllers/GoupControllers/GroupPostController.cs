using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Configs.AutoMapper;
using Web.Models.Enums;
using Web.Models.Interfaces.Domains;
using Web.Models.Interfaces.Stores;
using Web.Models.Models;

namespace Web.Api.Controllers.GoupControllers
{
    [ApiController]
    [Authorize]
    public class GroupPostController: ControllerBase
    {
        IGroupsDbStore _context;
        IPost _post;
        IMapper _mapper;

        public GroupPostController(IGroupsDbStore context, IPost post)
        {
            _context = context;
            _post=post;
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperConfig>();
            });
            _mapper=new Mapper(config);
        }

        [HttpPost("/group/createPost")]
        public async Task<IActionResult> createPost([FromForm] PostModel model, string group)
        {
            await _post.CreatePost(model, group, CreatorPost.Group);
            return Ok();
        }
    }
}