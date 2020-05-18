using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Entity;
using Web.Models.Interfaces.Domains;

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
        

        [HttpGet("/account/getLogin")]
        public IActionResult getLogin(){
            return Ok(_Account.GetAva(User.Identity.Name).Result);
        }



        [HttpGet("/user/getInfo")]
        [AllowAnonymous]
        public async Task<IActionResult> getInfo(string login)
        {
            return Ok(await _Account.getInfoUser(login));
        }
    }

}