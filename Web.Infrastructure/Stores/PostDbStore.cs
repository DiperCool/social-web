using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models.Db;
using Web.Models.Entity;
using Web.Models.Interfaces.Stores;

namespace Web.Infrastructure.Stores
{
    public class PostDbStore: IPostDbStore
    {
        Context _context;
        public PostDbStore(Context context)
        {
            _context=context;
        }

        public async Task<Post> SavePost(string login, Post post)
        {
            User user= await _context.Users
                .FirstOrDefaultAsync(x=>x.Login==login);
            post.user=user;
            user.Posts.Add(post);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return post;
        }


        public int countPosts(string login){
            return _context.Posts
                        .AsNoTracking()
                        .Where(x=>x.user.Login==login)
                        .Count();
        }

        public List<Post> GetPosts(string login, int pageSize, int page){
            List<Post> posts=_context.Posts
                .AsNoTracking()
                .Where(x=>x.user.Login==login)
                .OrderByDescending(x=>x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(x=>x.user)
                    .ThenInclude(x=>x.Ava)
                .Include(x=>x.Photos)
                .ToList();
            return posts;

        }

        public List<Img> DeletePhotosInPost(string login, int postId, List<int> photosId)
        {
            List<Img> photoDelete= new List<Img>();
            Post post= _context.Posts
                        .Where(x=>x.Id==postId&&x.user.Login==login)
                        .Include(x=>x.Photos)
                        .FirstOrDefault();
            if(post==null) return null;
            foreach (var item in post.Photos.Where(item => photosId.Any(x => x == item.Id)).ToList())
            {
                post.Photos.Remove(item);
                photoDelete.Add(item);
            }

            _context.Posts.Update(post);
            _context.SaveChanges();
            return photoDelete;
        }
        public async Task<Post> GetPostUser(string login, int id){
            Post post= await _context.Posts
                        .AsNoTracking()
                        .Where(x=>x.user.Login==login&&x.Id==id)
                        .Include(x=>x.Photos)
                        .Include(x=>x.user)
                        .FirstOrDefaultAsync();
            if(post==null) return null;
            return post;
        }
        public void changeDescPost(int idPost, string newDesc)
        {
            Post post = _context
                        .Posts
                        .Where(x=>x.Id==idPost)
                        .FirstOrDefault();
            post.Description=newDesc;
            _context.Update(post);
            _context.SaveChanges();
        }
        public List<Img> saveNewPhotoForPost(List<Img> imgs, int idPost,string login){
            Post post = _context
                        .Posts
                        .Where(x=>x.Id==idPost&&x.user.Login==login)
                        .FirstOrDefault();
            post.Photos.AddRange(imgs);
            _context.Posts.Update(post);
            _context.SaveChanges();
            return post.Photos;
        }

        public async Task<Post> GetPostAnyUser(int id, string login)
        {
            return await _context.Posts
                    .Where(x=>x.Id==id&&x.user.Login==login)
                    .Include(x=>x.user)
                        .ThenInclude(x=>x.Ava)
                    .Include(x=>x.Photos)
                    .FirstOrDefaultAsync();
        }
    }
}