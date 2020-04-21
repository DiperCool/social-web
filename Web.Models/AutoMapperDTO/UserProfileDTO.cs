

using Web.Models.Entity;

namespace Web.Models.AutoMapperDTO
{
    public class UserProfileDTO
    {
        public string Login{get;set;}
        public string Emeil{get;set;}
        public ImgDTO Ava{get;set;}
        public UserInfo InfoUser {get;set;}
    }
}