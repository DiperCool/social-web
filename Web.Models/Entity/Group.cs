using System.Collections.Generic;

namespace Web.Models.Entity
{
    public class Group
    {
        public int Id{get;set;}
        public string Login{get;set;}
        public GroupInfo Info{get;set;}
        public User Creator{get;set;}
        public List<UsersGroups> Users{get;set;}= new List<UsersGroups>();
        public List<AdminGroup> Admins{get;set;}= new List<AdminGroup>();
        public List<Post> Posts{get;set;}= new List<Post>();
        public Img Ava{get;set;}
    }
}