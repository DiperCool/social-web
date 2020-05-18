using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Web.Models.AutoMapperDTO;
using Web.Models.Configs.Urls;
using Web.Models.Entity;
using Web.Models.Interfaces;
using Web.Models.Interfaces.Stores;
using Web.Models.Interfaces.Domains;

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