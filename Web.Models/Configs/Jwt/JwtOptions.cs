using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Web.Models.Configs.Jwt
{
    public class JwtOptions
    {
        public const string ISSUER = "ASP.NET CORE";
        public const string AUDIENCE = "REACT";
        const string KEY = "DFOGOJDFOGJDOFGDFGJIDGDIGDFGJDFGJDFG";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}