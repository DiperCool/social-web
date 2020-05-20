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

namespace Web.Domain.SearchUsers
{
    public class SearchUsers:ISearchUsers
    {
        private ISearchUsersDbStore _context;
        private IMapper _mapper;
        public SearchUsers(ISearchUsersDbStore context)
        {
            _context = context;
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperConfig>();
            });
            _mapper = new Mapper(config);
        }

        public PaginationResult<UserDTO> GetUserWithContains(string contains, int page)
        {
            int CountPages= _context.CountUsers(contains);
            int size=5;
            var pag= new Pagination(CountPages,page,size);
            if(!pag.HasNextPage) return new PaginationResult<UserDTO>{
                Result= new List<UserDTO>(),
                isEnd=true
            };
            List<User> users= _context.GetUserWithContains(contains,size,page);
            List<UserDTO> usersDto=_mapper.Map<List<User>,List<UserDTO>>(users);
            return new PaginationResult<UserDTO>{
                Result= usersDto,
                isEnd=!pag.HasNextPageOne,
            };
        }
    }
}