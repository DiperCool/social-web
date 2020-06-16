using System;
using System.Collections.Generic;
using AutoMapper;
using Web.Infrastructure.Pagination;
using Web.Models.AutoMapperDTO;
using Web.Models.Configs.AutoMapper;
using Web.Models.Entity;
using Web.Models.EntityModels;
using Web.Models.Interfaces.Domains;
using Web.Models.Interfaces.Stores;
using Web.Models.Models;

namespace Web.Domain.Subscribers
{
    public class Subscribers: ISubscribers
    {
        private ISubscribersDbStore _context;
        private IMapper _mapper;
        public Subscribers(ISubscribersDbStore context)
        {
            _context = context;
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperConfig>();
            });
            _mapper = new Mapper(config);
        }

        public void SubscribeToUser(string to, string who)
        {
            _context.SubscribeToUser(to, who);
        }

        public void UnSubscribeUser(string to, string who)
        {
            _context.UnSubscribeUser(to, who);
        }

        public PaginationResult<SubscriberDTO> GetSubscribers(string login, int page)
        {
            int size=1;
            List<SubscriberEntity> users = _context.GetSubscribers(login, page, size);
            List<SubscriberDTO> usersDto=_mapper.Map<List<SubscriberEntity>,List<SubscriberDTO>>(users);
            return new PaginationResult<SubscriberDTO>{
                Result= usersDto,
                isEnd=usersDto.Count<size,
            };
        }

        public PaginationResult<SubscriberDTO> GetSubscribed(string login, int page)
        {
            int size=1;
            List<SubscriberEntity> users = _context.GetSubscribed(login, page, size);
            List<SubscriberDTO> usersDto=_mapper.Map<List<SubscriberEntity>,List<SubscriberDTO>>(users);
            return new PaginationResult<SubscriberDTO>{
                Result= usersDto,
                isEnd=usersDto.Count<size,
            };
        }
        public bool UserIsSubscribed(string to,string who)
        {
            return _context.UserIsSubscribed(to, who);
        }
    }
}