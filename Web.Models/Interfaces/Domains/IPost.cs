using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Web.Models.AutoMapperDTO;
using Web.Models.Enums;
using Web.Models.Models;

namespace Web.Models.Interfaces.Domains
{
    public interface IPost
    {
        Task<PostDTO> CreatePost(PostModel model, string login,CreatorPost creator);
        PaginationResult<LikeDTO> GetPostsUser(string login, int page,string loginLike);
        Task<PostDTO> GetPostUser(string login, int id);
        void DeletePhotosInPost(List<int> idPhotos, int idPost, string login);
        void changeDescPost(int idPost, string newDesc);
        Task<List<ImgDTO>> saveNewPhotoForPost(IFormFileCollection imgs, int idPost, string login);

        Task<PostDTO> GetPostAnyUser(int id, string login);
    }
}