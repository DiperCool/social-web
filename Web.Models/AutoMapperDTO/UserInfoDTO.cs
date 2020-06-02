namespace Web.Models.AutoMapperDTO
{
    public class UserInfoDTO
    {
        public ImgDTO Ava{get;set;}
        public string InfoUserAboutMe{get;set;}
        public string InfoUserName{get;set;}
        public string InfoUserGender{get;set;}
        public int CountSubscribers {get;set;}
        public int CountSubscribed{get;set;}
    }
}