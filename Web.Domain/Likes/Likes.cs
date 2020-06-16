using System.Collections.Generic;
using AutoMapper;
using Web.Models.AutoMapperDTO;
using Web.Models.Configs.AutoMapper;
using Web.Models.Entity;
using Web.Models.EntityModels;
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

        public PaginationResult<SubscriberDTO> getLikes(LikeType type, int id, int page)
        {
            int pageSize=5;
            List<SubscriberEntity> posts= _context.getLikes(type, id, page,pageSize);
            List<SubscriberDTO> postsDto=_mapper.Map<List<SubscriberEntity>,List<SubscriberDTO>>(posts);
            return new PaginationResult<SubscriberDTO>{
                Result= postsDto,
                isEnd=posts.Count<pageSize?true:false,
            };
        }

        public bool isLike(LikeType type, int id, string login)
        {
            return true;
        }

        public Like SetLike(string login, LikeType type, int id)
        {
            _context.SetLike(login, type,id);
            return new Like();
        }

        public void UnLike(string login, LikeType type, int id)
        {
            _context.UnLike(login, type, id);
        }
    }
}