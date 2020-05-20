using System.Collections.Generic;
using System.Security.Claims;
using Project.Models;
using Web.Infrastructure.Jwt;
using Web.Models.Entity;
using Web.Models.Models;
using Microsoft.AspNetCore.Hosting;
using Web.Models.Configs.Urls;
using Web.Models.Interfaces.Stores;
using Web.Models.Interfaces;
using Web.Models.Interfaces.Domains;
namespace Web.Domain.Auth
{
    public class Auth : IAuth
    {
        public IAuthDbStore _context;
        private IJwt _jwt;
        private IWebHostEnvironment _appEnvironment;
        public Auth(IAuthDbStore context, IJwt jwt,IWebHostEnvironment appEnvironment)
        {
            _appEnvironment=appEnvironment;
            _context=context;
            _jwt=jwt;
        }
        public ReturnTokens login(LoginModel model)
        {
            User user = _context.getUser(model.Login, model.Password);
            if(user==null) return null;
            string refreshtoken=_jwt.GenereteRefreshToken();
            _jwt.SaveRefreshToken(refreshtoken, model.Login);
            IEnumerable<Claim> claims= new List<Claim>(){
                new Claim(ClaimsIdentity.DefaultNameClaimType, model.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "user")
            };
            string token=_jwt.GenereteJwtToken(claims);
            return new ReturnTokens(token, refreshtoken);
            
        }

        public ReturnTokens RefreshingToken(ReturnTokens model)
        {
            ClaimsPrincipal principal= _jwt.GetClaimsPrincipalOfExpiredJwt(model.Token);
            if(principal==null) return null;
            if(!_jwt.CheckHaveUserTheToken(model.RefreshToken, principal.Identity.Name)) return null;
            string newRefreshToken=_jwt.GenereteRefreshToken();
            _jwt.SaveRefreshToken( newRefreshToken,principal.Identity.Name);
            string newToken= _jwt.GenereteJwtToken(principal.Claims);
            return new ReturnTokens(newToken, newRefreshToken);
        }

        public ReturnTokens register(RegistarationValidation model)
        {
            string refreshToken= _jwt.GenereteRefreshToken();
            User user= new User(){
                Login=model.Login,
                Ava= new Img{
                    PathImg=_appEnvironment.WebRootPath+"/Files/defaultAva/default.jpg",
                    UrlImg=Config.CurrentUrl+"Files/defaultAva/default.jpg"},
                Password=model.Password,
                Emeil=model.Emeil,
                InfoUser= new UserInfo(),
                RefreshToken=refreshToken,
            };
            IEnumerable<Claim> claims= new List<Claim>(){
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "user")
            };
            string token= _jwt.GenereteJwtToken(claims);
            _context.createUser(user);
            return new ReturnTokens(token, refreshToken);
        }
    }
}