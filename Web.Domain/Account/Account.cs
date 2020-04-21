using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Web.Models.AutoMapperDTO;
using Web.Models.Configs.Urls;
using Web.Models.Entity;
using Web.Models.Interfaces;
using Web.Models.Models;

namespace Web.Domain.Account
{
    public class Account : IAccount
    {

        IProfileDbStore _context;
        IValidation _valid;
        IWebHostEnvironment _appEnvironment;
        IFilesWorker _file;
        public Account(IWebHostEnvironment appEnvironment,IProfileDbStore context, IValidation valid, IFilesWorker file)  
        {
            _appEnvironment=appEnvironment;
            _context=context;
            _valid=valid;
            _file=file;
        }
        public async Task<UserInfo> ChangeInfo(UserInfo info, string login)
        {
            if(!_valid.GenderCheck(info.Gender)) return null;
            await _context.SaveUserInfo(login, info);
            return info;
        }


        public async Task<PostDTO> CreatePost(PostModel postModel, string login)
        {
            var photos= postModel.Photos;
            if(photos==null) return null;
            Post post= new Post{
                Description=postModel.Description
            };
            foreach(var photo in photos)
            {
                string ext = Path.GetExtension(photo.FileName);
                string pathToUrl = "Files/PhotosPosts/" + Guid.NewGuid() + ext;
                string path = _appEnvironment.WebRootPath + "/" + pathToUrl;
                await _file.createFile(photo, path);
                string pathUrl = Config.CurrentUrl + pathToUrl;
                post.Photos.Add(new Img { PathImg = path, UrlImg = pathUrl });
            }
            PostDTO postDto=await _context.SavePost(login, post);
            return postDto;
        }


        public async Task<UserProfileDTO> GetUserProfile(string login)
        {
            return await _context.GetUserProfile(login);
        }

        public async Task<string> SaveAva(IFormFile photo, string login)
        {
            if (photo != null)
            {
                string ext=Path.GetExtension(photo.FileName);
                string pathToUrl="Files/Avas/" + Guid.NewGuid()+ext;
                string path = _appEnvironment.WebRootPath+"/"+pathToUrl;               
                await _file.createFile(photo, path);
                string pathUrl=Config.CurrentUrl+pathToUrl;
                await _context.SaveAvaPath(login, new Img{PathImg=path, UrlImg=pathUrl});
                return pathUrl;
            }
            return null;
        }

        public PaginationPostResult GetPostsUser(string login, int page)
        {
            return _context.GetPosts(login, page);
        }
        public async Task<PostDTO> GetPostUser(string login, int id){
            return await _context.GetPostUser(login, id);
        }
        public void DeletePhotosInPost(List<int> idPhotos, int idPost, string login){
            _context.DeletePhotosInPost(login, idPost, idPhotos);
        }

        public void changeDescPost(int idPost, string newDesc)
        {
            _context.changeDescPost(idPost, newDesc);
        }

        public async Task<List<ImgDTO>> saveNewPhotoForPost(IFormFileCollection imgs, int idPost,string login)
        {
            List<Img> imgsConvert= new List<Img>();
            foreach(var photo in imgs){
                string ext = Path.GetExtension(photo.FileName);
                string pathToUrl = "Files/PhotosPosts/" + Guid.NewGuid() + ext;
                string path = _appEnvironment.WebRootPath + "/" + pathToUrl;
                await _file.createFile(photo, path);
                string pathUrl = Config.CurrentUrl + pathToUrl;
                imgsConvert.Add(new Img { PathImg = path, UrlImg = pathUrl });
            }
            return _context.saveNewPhotoForPost(imgsConvert,idPost,login);

        }
        public async Task<UserInfoDTO> getInfoUser(string login)
        {
            return await _context.getInfoUser(login);
        }
        public async Task<AvaDTO> GetAva(string login)
        {
            return await _context.GetAva(login);
        }
    }
}