using Web.Models.Entity;

namespace Web.Models.EntityModels
{
    public class LikeCommentEntity
    {
        public Comment Comment{get;set;}
        public bool IsLike{get;set;}
    }
}