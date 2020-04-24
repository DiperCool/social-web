using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Interfaces;
using Web.Models.Models;

namespace Web.Api.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        IPost _Account;
        public PostController(IPost Account)
        {
            _Account=Account;
        }
        [HttpPost("/account/getPostsUser")]
        [AllowAnonymous]
        public IActionResult getPostsUser([FromBody] PaginationModel model){
            return Ok(_Account.GetPostsUser(model.Login, model.Page));
        }

        [HttpPost("/account/createPost")]
        public async Task<IActionResult> createPost([FromForm]PostModel model){
            return Ok(await _Account.CreatePost(model, User.Identity.Name));
        }

        [HttpGet("/account/getPost")]
        public IActionResult getPost(int idPost){
            return Ok(_Account.GetPostUser(User.Identity.Name, idPost));
        }
        [HttpPost("/post/changeDesc")]
        public IActionResult changeDesc(int idPost, string newDesc){
            _Account.changeDescPost(idPost, newDesc);
            return Ok();
        }

        [HttpPost("/post/saveNewPhoto")]
        public IActionResult saveNewPhoto([FromForm] newPhotoForPostModel model){
            return Ok(_Account.saveNewPhotoForPost(model.imgs,model.idPost, User.Identity.Name));
        }
        [HttpPost("Post/deletePhotos")]
        public IActionResult deletePhotos([FromBody] DeletePhotos model){
            _Account.DeletePhotosInPost(model.idPhotos, model.idPost, User.Identity.Name);
            return Ok(new {model, User.Identity.Name});
        }
    }

}