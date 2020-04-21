using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Web.Models.Configs.Jwt;
using Web.Models.Interfaces;

namespace Web.Infrastructure.Jwt
{
    public class JwtLib : IJwt
    {

        private IAuthDbStore _context;
        public JwtLib(IAuthDbStore context)
        {
            _context=context;
        }
        

        public bool CheckHaveUserTheToken(string token,string login)
        {
            return _context.checkUserHaveRefreshToken(login,token);
        }

        public string GenereteJwtToken(IEnumerable<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                issuer: JwtOptions.ISSUER,
                audience: JwtOptions.AUDIENCE,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(JwtOptions.LIFETIME),
                signingCredentials: new SigningCredentials(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );    

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string GenereteRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create()){
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber).Replace("+", "A").Replace("/", "B").Replace("=", "C");
            }
        }

        public ClaimsPrincipal GetClaimsPrincipalOfExpiredJwt(string token)
        {
            
            if (token == null) return null;

            var param = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = JwtOptions.GetSymmetricSecurityKey()
            };

            SecurityToken security;

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, param, out security);

            JwtSecurityToken newJwtToken = security as JwtSecurityToken;

            if (newJwtToken == null || !newJwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        public void SaveRefreshToken(string token, string login)
        {
            _context.saveRefreshToken(login, token);
        }
    }
}