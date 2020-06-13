using System.Collections.Generic;
using AutoMapper;
using Web.Models.AutoMapperDTO;
using Web.Models.Configs.AutoMapper;
using Web.Models.Entity;
using Web.Models.Enums;
using Web.Models.Interfaces.Domains;
using Web.Models.Interfaces.Stores;
using Web.Models.Models;

namespace Web.Domain.Likes
{
    public class Likes : ILikes
    {
        private ILikesDbStore _context;
        private IMapper _mapper;
        public Likes(ILikesDbStore context)
        {
            _context = context;
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperConfig>();
            });
            _mapper = new Mapper(config);
        }

        public PaginationResult<UserDTO> getLikes(LikeType type, int id, int page)
        {
            int pageSize=5;
            List<User> posts= _context.getLikes(type, id, page,pageSize);
            List<UserDTO> postsDto=_mapper.Map<List<User>,List<UserDTO>>(posts);
            return new PaginationResult<UserDTO>{
                Result= postsDto,
                isEnd=posts.Count<pageSize?true:false,
            };
        }

        public bool isLike(LikeType type, int id, string login)
        {
            throw new System.NotImplementedException();
        }

        public Like SetLike(string login, LikeType type, int id)
        {
            throw new System.NotImplementedException();
        }

        public void UnLike(string login, LikeType type, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}