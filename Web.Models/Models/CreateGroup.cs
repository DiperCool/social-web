using System.ComponentModel.DataAnnotations;

namespace Web.Models.Models
{
    public class CreateGroup
    {
        [Required]
        public string Login{get;set;}
        [Required]
        public string Name{get;set;}
    }
}