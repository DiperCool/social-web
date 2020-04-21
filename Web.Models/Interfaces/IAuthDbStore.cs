using Web.Models.Entity;

namespace Web.Models.Interfaces
{
    public interface IAuthDbStore
    {
         User getUser(string login,string password);
         bool checkUserHaveRefreshToken(string login, string refreshToken);
         void saveRefreshToken(string login,string token);
         void createUser(User user);
         
    }
}