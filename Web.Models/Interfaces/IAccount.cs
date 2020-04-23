using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Web.Models.AutoMapperDTO;
using Web.Models.Entity;

namespace Web.Models.Interfaces
{
    public interface IAccount
    {
        Task<AvaDTO> GetAva(string login);
        Task<UserInfoDTO> getInfoUser(string login);
        Task<string> SaveAva(IFormFile photo, string login);
        Task<UserInfo> ChangeInfo(UserInfo info, string login);
        Task<UserProfileDTO> GetUserProfile(string login);
    }
}