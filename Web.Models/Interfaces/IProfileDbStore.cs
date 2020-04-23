using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models.AutoMapperDTO;
using Web.Models.Entity;
using Web.Models.Models;

namespace Web.Models.Interfaces
{
    public interface IProfileDbStore
    {
        Task<AvaDTO> GetAva(string login);
        Task<UserInfoDTO> getInfoUser(string login);
        Task SaveAvaPath(string login, Img path);
        Task SaveUserInfo(string login, UserInfo info);
        Task<UserProfileDTO> GetUserProfile(string login);
    }
}