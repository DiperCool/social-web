using Web.Models.Enums;

namespace Web.Models.Entity
{
    public class Like
    {
        public int Id{get;set;}
        public User Who{get;set;}
        public LikeType Type{get;set;}
        public int IdType{get;set;}
    }
}