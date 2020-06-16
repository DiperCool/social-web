using Web.Models.Entity;

namespace Web.Models.EntityModels
{
    public class LikeEntity
    {
        public Post Post{get;set;}
        public bool IsLike{get;set;}
    }
}