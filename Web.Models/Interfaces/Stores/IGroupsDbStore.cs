

using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models.Entity;
using Web.Models.Enums;

namespace Web.Models.Interfaces.Stores
{
    public interface IGroupsDbStore
    {
        Task<Group> createGroup(string login, string name,string loginCreator);
        Task<User> setAdmin(string loginGroup, string loginUser, List<RightType> right);
        Task<User> changeAdminRights(string loginGroup, string loginUser, List<RightType> right);
        Task deleteAdmin(string loginGroup, string loginUser);
        Task<User> addToGroup(string loginGroup, string loginUser);
        Task deleteFromGroup(string loginGroup, string loginUser);
        Task<List<RightType>> getRight(string loginGroup, string loginUser);
        Task<bool>  loginIsExist(string login);
        Task<Img> saveAva(string login,Img img);
        Task<bool> userIsSubscribed(string login, string loginGroup);
        Task<GroupInfo> changeGroupInfo(GroupInfo info);
        Task<bool> userIsCreator(string loginGroup, string loginCreator);
        Task<bool> userIsAdmin(string loginGroup, string loginCreator);
        List<AdminGroup> GetAdminGroups(string loginGroup,int size, int id);
        Task<Group> getGroupWithGroupInfo(string loginGroup);
    }
}