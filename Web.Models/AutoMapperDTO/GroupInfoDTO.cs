using System.ComponentModel.DataAnnotations;

namespace Web.Models.AutoMapperDTO
{
    public class GroupInfoDTO
    {
        [Required]
        public int Id{get;set;}
        [Required]
        public string Name{get;set;}
        [Required]
        public string Description{get;set;}
        
    }
}