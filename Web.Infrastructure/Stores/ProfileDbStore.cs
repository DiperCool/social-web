using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Models.Db;
using Web.Models.AutoMapperDTO;
using Web.Models.Configs.AutoMapper;
using Web.Models.Entity;
using Web.Models.Interfaces;
using Web.Models.Models;

namespace Web.Infrastructure.Stores
{
    public class ProfileDbStore : IProfileDbStore
    {
        private Context _context;
        private IFilesWorker _file;
        private IMapper _mapper;
        public ProfileDbStore(Context context, IFilesWorker file)
        {
            _file=file;
            _context=context;
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperConfig>();
            });
            _mapper = new Mapper(config);
        }
        public async Task SaveAvaPath(string login, Img img)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x=>x.Login==login);
            if(user==null) return;
            user.Ava=img;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task SaveUserInfo(string login, UserInfo info)
        {
            bool result=await _context.Users.AnyAsync(x=>x.Login==login&&x.InfoUser.Id==info.Id);
            if(!result) return;
            _context.Infos.Update(info);
            await _context.SaveChangesAsync();
        }

        public async Task<UserProfileDTO> GetUserProfile(string login)
        {
            User user= await _context.Users
                .AsNoTracking()
                .Where(x=>x.Login==login)
                .Include(x=>x.Ava)
                .Include(x=>x.InfoUser)
                .FirstOrDefaultAsync();
            UserProfileDTO userDTO= _mapper.Map<UserProfileDTO>(user);
            return userDTO;
        }

        public async Task<PostDTO> SavePost(string login, Post post)
        {
             User user= await _context.Users
                .FirstOrDefaultAsync(x=>x.Login==login);
            post.user=user;
            user.Posts.Add(post);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            PostDTO postDTO= _mapper.Map<Post, PostDTO>(post);
            return postDTO;
        }

        public PaginationPostResult GetPosts(string login, int page){
            int amountPages= _context.Posts
                                .AsNoTracking()
                                .Where(x=>x.user.Login==login)
                                .Count();
            var pageSize=5;
            Console.WriteLine(amountPages);
            var pag= new Pagination.Pagination(amountPages,page,pageSize);
            if(!pag.HasNextPage) return new PaginationPostResult{
                Posts= new List<PostDTO>(),
                isEnd=true
            };
            List<Post> posts=_context.Posts
                .AsNoTracking()
                .Where(x=>x.user.Login==login)
                .OrderByDescending(x=>x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(x=>x.Photos)
                .ToList();
            List<PostDTO> listDto= _mapper.Map<List<Post>,List<PostDTO>>(posts);
            return new PaginationPostResult{
                Posts=listDto,isEnd=false
            };

        }

        public List<Img> DeletePhotosInPost(string login, int postId, List<int> photosId)
        {
            List<Img> imgDel= new List<Img>();
            Post post= _context.Posts
                        .Where(x=>x.Id==postId&&x.user.Login==login)
                        .Include(x=>x.Photos)
                        .FirstOrDefault();
            if(post==null) return null;
            foreach (var item in post.Photos.Where(item => photosId.Any(x => x == item.Id)).ToList())
            {
                imgDel.Add(item);
                post.Photos.Remove(item);
            }

            _context.Posts.Update(post);
            _context.SaveChanges();
            return imgDel;
        }
        public async Task<PostDTO> GetPostUser(string login, int id){
            Post post= await _context.Posts
                        .AsNoTracking()
                        .Where(x=>x.user.Login==login&&x.Id==id)
                        .Include(x=>x.Photos)
                        .Include(x=>x.user)
                        .FirstOrDefaultAsync();
            if(post==null) return null;
            return _mapper.Map<Post, PostDTO>(post);
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
        public List<ImgDTO> saveNewPhotoForPost(List<Img> imgs, int idPost,string login){
            Post post = _context
                        .Posts
                        .Where(x=>x.Id==idPost&&x.user.Login==login)
                        .FirstOrDefault();
            post.Photos.AddRange(imgs);
            _context.Posts.Update(post);
            _context.SaveChanges();
            return _mapper.Map<List<Img>, List<ImgDTO>>(post.Photos);
        }

        public async Task<UserInfoDTO> getInfoUser(string login)
        {
            User user= await _context.Users
                            .AsNoTracking()
                            .Where(x=>x.Login==login)
                            .Include(x=>x.Ava)
                            .Include(x=>x.InfoUser)
                            .FirstOrDefaultAsync();
            UserInfoDTO infoDTO= _mapper.Map<User, UserInfoDTO>(user);
            return infoDTO;
        }

        public async Task<AvaDTO> GetAva(string login)
        {
            User user= await _context.Users
                        .AsNoTracking()
                        .Where(x=>x.Login==login)
                        .Include(x=>x.Ava)
                        .FirstOrDefaultAsync();
            return _mapper.Map<User, AvaDTO>(user);
        }
    }
}