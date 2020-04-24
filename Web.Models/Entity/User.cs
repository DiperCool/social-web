using System.Collections.Generic;

namespace Web.Models.Entity
{
    public class User
    {
        public int Id{get;set;}
        public string Login{get;set;}
        public string Password{get;set;}
        public string RefreshToken{get;set;}
        public string Emeil{get;set;}
        public Img Ava{get;set;}
        public UserInfo InfoUser {get;set;}
        public List<Post> Posts{get;set;}= new List<Post>();
        public List<Comment> Comments{get;set;}= new List<Comment>();
    }
}