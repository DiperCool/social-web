using System.Collections.Generic;
using Web.Models.Entity;

namespace Web.Models.Interfaces.Stores
{
    public interface ISearchUsersDbStore
    {
        List<User> GetUserWithContains(string contains, int pageSize, int page);
        int CountUsers(string contains);
    }
}