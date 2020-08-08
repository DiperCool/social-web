using System.Collections.Generic;
using Web.Models.Enums;

namespace Web.Models.Entity
{
    public class AdminGroup
    {
        public int Id{get;set;}
        public User User{get;set;}
        public List<RightAdmin> Rights{get;set;}= new List<RightAdmin>();
        public Group Group{get;set;}
    }
}