using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project.Models.Db;
using Web.Models.Entity;
using Web.Models.Interfaces.Stores;

namespace Web.Infrastructure.Stores
{
    public class SearchUserDbStore:ISearchUsersDbStore
    {
        private Context _context;
        public SearchUserDbStore(Context context)
        {
            _context = context;
        }
        public List<User> GetUserWithContains(string contains, int pageSize, int page){
            List<User> users=_context.Users
                .AsNoTracking()
                .Where(x=>x.Login.Contains(contains))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(x=>x.Ava)
                .ToList();
            return users;
        }

        public int CountUsers(string contains)
        {
            return _context
                .Users
                .Where(x => x.Login.Contains(contains))
                .Count();
        }
    }
}