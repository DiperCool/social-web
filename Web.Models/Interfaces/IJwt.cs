using System.Collections.Generic;
using System.Security.Claims;

namespace Web.Models.Interfaces
{
    public interface IJwt
    {
        string GenereteJwtToken(IEnumerable<Claim> claims);
        ClaimsPrincipal GetClaimsPrincipalOfExpiredJwt(string token);
        string GenereteRefreshToken();
        void SaveRefreshToken(string token,string login);
        bool CheckHaveUserTheToken(string token,string login);
    }
}