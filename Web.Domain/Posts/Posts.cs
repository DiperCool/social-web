using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Web.Infrastructure.Pagination;
using Web.Models.AutoMapperDTO;
using Web.Models.Configs.AutoMapper;
using Web.Models.Configs.Urls;
using Web.Models.Entity;
using Web.Models.Interfaces;
using Web.Models.Interfaces.Domains;
using Web.Models.Models;
using Web.Models.Interfaces.Stores;

namespace Web.Domain.Posts
{
    public class Posts:IPost
    {
        IPostDbStore _context;
        IValidation _valid;
        IWebHostEnvironment _appEnvironment;
        IFilesWorker _file;
        IMapper _mapper;
        public Posts(IWebHostEnvironment appEnvironment,IPostDbStore context, IValidation valid, IFilesWorker file)  
        {
            _appEnvironment=appEnvironment;
            _context=context;
            _valid=valid;
            _file=file;
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperConfig>();
            });
            _mapper = new Mapper(config);
        }
        public PaginationResult<PostDTO> GetPostsUser(string login, int page)
        {
            int size=5;
            List<Post> posts= _context.GetPosts(login, size,page);
            List<PostDTO> postsDto=_mapper.Map<List<Post>,List<PostDTO>>(posts);
            return new PaginationResult<PostDTO>{
                Result= postsDto,
                isEnd=posts.Count<size?true:false,
            };
        }
        public async Task<PostDTO> GetPostUser(string login, int id){
            return _mapper.Map<Post, PostDTO>(await _context.GetPostUser(login, id));
        }
        public void DeletePhotosInPost(List<int> idPhotos, int idPost, string login){
            var imgs=_context.DeletePhotosInPost(login, idPost, idPhotos);
            foreach(var item in imgs){
                _file.deleteFile(item.PathImg);
            }
        }

        public void changeDescPost(int idPost, string newDesc)
        {
            _context.changeDescPost(idPost, newDesc);
        }

        public async Task<PostDTO> CreatePost(PostModel model, string login)
        {
            var photos= model.Photos;
            if(photos==null) return null;
            Post post= new Post{
                Description=model.Description
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
            PostDTO postDto=_mapper.Map<Post, PostDTO>(await _context.SavePost(login, post));
            return postDto;
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
            return _mapper.Map<List<Img>,List<ImgDTO>>(_context.saveNewPhotoForPost(imgsConvert,idPost,login));

        }
        public async Task<PostDTO> GetPostAnyUser(int idPost, string login){
            return _mapper.Map<Post, PostDTO>(await _context.GetPostAnyUser(idPost, login));
        }
    }
}