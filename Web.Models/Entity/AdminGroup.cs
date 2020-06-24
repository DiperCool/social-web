using Web.Models.Enums;

namespace Web.Models.Entity
{
    public class AdminGroup
    {
        public int Id{get;set;}
        public User User{get;set;}
        public RightType Right{get;set;}
        public Group Group{get;set;}
    }
}