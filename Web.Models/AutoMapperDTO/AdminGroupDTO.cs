using System.Collections.Generic;
using Web.Models.Entity;

namespace Web.Models.AutoMapperDTO
{
    public class AdminGroupDTO
    {
        public int Id{get;set;}
        public UserDTO User{get;set;}
        public List<RightAdminDTO> Rights{get;set;}
    }
}