using System;
using System.Collections.Generic;
using AutoMapper;
using Web.Infrastructure.Pagination;
using Web.Models.AutoMapperDTO;
using Web.Models.Configs.AutoMapper;
using Web.Models.Entity;
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

        public PaginationResult<UserDTO> GetSubscribers(string login, int page)
        {
            int CountPages = _context.CountSubscribers(login);
            int size=1;
            var pag= new Pagination(CountPages,page,size);
            if(!pag.HasNextPage) return new PaginationResult<UserDTO>{
                Result= new List<UserDTO>(),
                isEnd=true
            };
            List<User> users = _context.GetSubscribers(login, page, size);
            List<UserDTO> usersDto=_mapper.Map<List<User>,List<UserDTO>>(users);
            return new PaginationResult<UserDTO>{
                Result= usersDto,
                isEnd=!pag.HasNextPageOne,
            };
        }

        public PaginationResult<UserDTO> GetSubscribed(string login, int page)
        {
            int CountPages = _context.CountSubscribed(login);
            int size=1;
            var pag= new Pagination(CountPages,page,size);
            if(!pag.HasNextPage) return new PaginationResult<UserDTO>{
                Result= new List<UserDTO>(),
                isEnd=true
            };
            List<User> users = _context.GetSubscribed(login, page, size);
            List<UserDTO> usersDto=_mapper.Map<List<User>,List<UserDTO>>(users);
            return new PaginationResult<UserDTO>{
                Result= usersDto,
                isEnd=!pag.HasNextPageOne,
            };
        }
        public bool UserIsSubscribed(string to,string who)
        {
            return _context.UserIsSubscribed(to, who);
        }
    }
}