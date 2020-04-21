using System.Linq;
using Project.Models.Db;
using Web.Models.Entity;
using Web.Models.Interfaces;

namespace Web.Infrastructure.Stores
{
    public class AuthDbStore : IAuthDbStore
    {

        private Context _context;
        public AuthDbStore(Context context)
        {
            _context=context;
        }

        public bool checkUserHaveRefreshToken(string login, string refreshToken)
        {
            User user= _context.Users.FirstOrDefault(x=>x.RefreshToken==refreshToken&&x.Login==login);
            if(user==null) return false;
            return true;
        }

        public void createUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User getUser(string login, string password)
        {
            User user = _context.Users.FirstOrDefault(x=>x.Login==login&&x.Password==password);
            return user;
        }

        public void saveRefreshToken(string login, string token)
        {
            User user= _context.Users.FirstOrDefault(x=>x.Login==login);
            if(user==null) return;
            user.RefreshToken=token;
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}