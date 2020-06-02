using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Web.Infrastructure.Jwt;
using Web.Models.Interfaces;
using Web.Models.Models;
using Web.Models.Interfaces.Domains;
namespace Web.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IValidation _validation;
        IWebHostEnvironment _appEnvironment;
        private IAuth _auth;
        public AuthController(IAuth auth, IValidation validation,IWebHostEnvironment appEnvironment)  
        {
            _appEnvironment=appEnvironment;
            _validation=validation;
            _auth=auth;
        }

        [HttpPost("/auth/login")]
        public IActionResult Login([FromBody] LoginModel model){
            var result=_auth.login(model);
            if(result==null){
                return BadRequest("Не верный пароль или пароль");
            }
            return Ok(result);
        }


        [HttpPost("/auth/register")]
        public IActionResult Register([FromBody] RegistarationValidation model){
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(_validation.isUsedLogin(model.Login)){
                ModelState.AddModelError("LoginExcaption","Такой логин существует");
                return BadRequest(ModelState);
            }
            return Ok(_auth.register(model));
        }
        [HttpPost("/auth/refreshingToken")]
        public IActionResult RefreshToken([FromBody] ReturnTokens model){
            ReturnTokens result= _auth.RefreshingToken(model);
            if(result==null) return BadRequest();
            return Ok(result);
        }

        [HttpGet("/test")]
        public IActionResult test()
        {
            if(HttpContext.Response.Headers["Token-Expired"]=="true")
            {
                return Ok("token expired");
            }
            if(User.Identity.IsAuthenticated)
            {
                return Ok(User.Identity.Name);
            }
            return Ok("None");

        }

    }
}
