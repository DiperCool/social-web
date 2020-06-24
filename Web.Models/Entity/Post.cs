using System.Collections.Generic;

namespace Web.Models.Entity
{
    public class Post
    {
        public int Id{get;set;}
        public string Description{get;set;}
        public List<Img> Photos{get;set;}= new List<Img>();
        public User user {get;set;}
        public Group group{get;set;}
        public List<Comment> Comments{get;set;}= new List<Comment>();
    }
}