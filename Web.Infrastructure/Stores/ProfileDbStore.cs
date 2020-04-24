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