using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Enums;
using Web.Models.Interfaces.Domains;
using Web.Models.Models;

namespace Web.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        IPost _Account;
        ILikes _Likes;
        public PostController(IPost Account,ILikes Likes)
        {
            _Account=Account;
            _Likes=Likes;
        }
        [HttpPost("/account/getPostsUser")]
        public IActionResult getPostsUser([FromBody] PaginationModel model){
            if(HttpContext.Response.Headers["Token-Expired"]=="true")
            {
                return Unauthorized();
            }
            if(User.Identity.IsAuthenticated)
            {
                return Ok(_Account.GetPostsUser(model.Login, model.Page, User.Identity.Name));
            }
            else
            {
                return Ok(_Account.GetPostsUser(model.Login, model.Page, null));
            }
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
        [HttpGet("/post/getAnyPostUser")]
        [AllowAnonymous]
        public IActionResult getAnyPostUser(int id, string login){
            return Ok(_Account.GetPostAnyUser(id,login).Result);
        }

        [HttpGet("/post/getLikes")]
        [AllowAnonymous]
        public IActionResult getLikes(int id, int page){
            return Ok(_Likes.getLikes(LikeType.Post, id, page));
        }
        [HttpPost("/post/setLike")]
        public IActionResult setLike(int id){
            return Ok(_Likes.SetLike(User.Identity.Name, LikeType.Post, id));
        }
        [HttpPost("/post/unLike")]
        public IActionResult unLike(int id){
            _Likes.UnLike(User.Identity.Name, LikeType.Post, id);
            return NoContent();
        }
    }

}