using AutoMapper;
using Web.Models.AutoMapperDTO;
using Web.Models.Entity;
using Web.Models.EntityModels;

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
            CreateMap<SubscriberEntity, SubscriberDTO>();
            CreateMap<LikeEntity, LikeDTO>();
        }
    }
}