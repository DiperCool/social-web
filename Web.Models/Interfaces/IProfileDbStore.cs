using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models.AutoMapperDTO;
using Web.Models.Entity;
using Web.Models.Models;

namespace Project.Models.Interfaces
{
    public interface IProfileDbStore
    {
        Task<AvaDTO> GetAva(string login);
        Task<UserInfoDTO> getInfoUser(string login);
        Task SaveAvaPath(string login, Img path);
        Task SaveUserInfo(string login, UserInfo info);
        Task<UserProfileDTO> GetUserProfile(string login);
        Task<PostDTO> SavePost(string login, Post post);
        PaginationPostResult GetPosts(string login,int page);
        void DeletePhotosInPost(string login, int postId, List<int> photosId);
        Task<PostDTO> GetPostUser(string login, int id);
        void changeDescPost(int idPost, string newDesc);
        List<ImgDTO> saveNewPhotoForPost(List<Img> imgs, int idPost,string login);
    }
}