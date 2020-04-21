using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Web.Models.AutoMapperDTO;
using Web.Models.Entity;
using Web.Models.Models;

namespace Web.Models.Interfaces
{
    public interface IAccount
    {
        Task<AvaDTO> GetAva(string login);
        Task<UserInfoDTO> getInfoUser(string login);
        Task<string> SaveAva(IFormFile photo, string login);
        Task<UserInfo> ChangeInfo(UserInfo info, string login);
        Task<UserProfileDTO> GetUserProfile(string login);
        Task<PostDTO> CreatePost(PostModel model, string login);
        PaginationPostResult GetPostsUser(string login, int page);
        Task<PostDTO> GetPostUser(string login, int id);
        void DeletePhotosInPost(List<int> idPhotos, int idPost, string login);
        void changeDescPost(int idPost, string newDesc);
        Task<List<ImgDTO>> saveNewPhotoForPost(IFormFileCollection imgs, int idPost, string login);
    }
}