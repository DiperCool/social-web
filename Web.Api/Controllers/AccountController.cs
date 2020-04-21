using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Entity;
using Web.Models.Interfaces;
using Web.Models.Models;

namespace Project.Controllers
{
    [Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {

        IAccount _Account;
        IWebHostEnvironment _appEnvironment;
        public AccountController(IWebHostEnvironment appEnvironment, IAccount Account)  
        {
            _appEnvironment=appEnvironment;
            _Account=Account;
        }
        [HttpPost("Post/deletePhotos")]
        public IActionResult deletePhotos([FromBody] DeletePhotos model){
            _Account.DeletePhotosInPost(model.idPhotos, model.idPost, User.Identity.Name);
            return Ok(new {model, User.Identity.Name});
        }

        [HttpPost("/account/uploadAvu")]
        public async Task<IActionResult> uploadAvu(IFormFile uploads)
        {

            string path=await _Account.SaveAva(uploads, User.Identity.Name);
            return Ok(path);     
        }


        [HttpGet("/account/getProfile")]
        public IActionResult getProfile(){
            return Ok(_Account.GetUserProfile(User.Identity.Name));
        }

        [HttpPost("/account/changeUserInfo")]
        public async Task<IActionResult> changeUserInfo([FromBody]UserInfo info){
            UserInfo result=await _Account.ChangeInfo(info, User.Identity.Name);
            if(result==null) return BadRequest();
            return Ok(_Account.ChangeInfo(info, User.Identity.Name));
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

        [HttpGet("/account/getLogin")]
        public IActionResult getLogin(){
            return Ok(_Account.GetAva(User.Identity.Name).Result);
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

        [HttpGet("/user/getInfo")]
        [AllowAnonymous]
        public async Task<IActionResult> getInfo(string login)
        {
            return Ok(await _Account.getInfoUser(login));
        } 
    }

}