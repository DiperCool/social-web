

using System.Threading.Tasks;
using Web.Models.Entity;
using Web.Models.Enums;

namespace Web.Models.Interfaces.Stores
{
    public interface IGroupsDbStore
    {
        Task<Group> createGroup(string login, string name);
        Task<User> setAdmin(string loginGroup, string loginUser, RightType right);
        Task deleteAdmin(string loginGroup, string loginUser);
        Task<User> addToGroup(string loginGroup, string loginUser);
        Task deleteFromGroup(string loginGroup, string loginUser);
        Task<RightType> getRight(string loginGroup, string loginUser);

    }
}