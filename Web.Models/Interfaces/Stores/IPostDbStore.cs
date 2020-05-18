using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models.Entity;

namespace Web.Models.Interfaces.Stores
{
    public interface IPostDbStore
    {
        List<Post> GetPosts(string login, int pageSize, int page);
        List<Img> DeletePhotosInPost(string login, int postId, List<int> photosId);
        Task<Post> GetPostUser(string login, int id);
        void changeDescPost(int idPost, string newDesc);
        List<Img> saveNewPhotoForPost(List<Img> imgs, int idPost,string login);
        Task<Post> SavePost(string login, Post post);
        int countPosts(string login);
        Task<Post> GetPostAnyUser(int id, string login);
    }
}