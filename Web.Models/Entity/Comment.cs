

namespace Web.Models.Entity
{
    public class Comment
    {
        public int Id{get;set;}
        public User To { get; set; }
        public string Content{get;set;}
        public Post Post{get;set;}
        public User Author{get;set;}
    }
}