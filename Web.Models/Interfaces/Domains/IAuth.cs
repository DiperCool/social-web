using Web.Infrastructure.Jwt;
using Web.Models.Models;

namespace Web.Models.Interfaces.Domains
{
    public interface IAuth
    {
        ReturnTokens register(RegistarationValidation model);
        ReturnTokens login(LoginModel model);
        ReturnTokens RefreshingToken(ReturnTokens model);
    }
}