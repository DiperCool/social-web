using AutoMapper;
using Web.Models.AutoMapperDTO;
using Web.Models.Entity;

namespace Web.Models.Configs.AutoMapper
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Comment, CommentDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<User, UserProfileDTO>();
            CreateMap<Post, PostDTO>();
            CreateMap<Img,ImgDTO>();
            CreateMap<User, UserInfoDTO>();
            CreateMap<User, AvaDTO>();
        }
    }
}