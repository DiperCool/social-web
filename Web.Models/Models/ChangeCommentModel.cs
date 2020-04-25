using System.ComponentModel.DataAnnotations;

namespace Web.Models.Models
{
    public class ChangeCommentModel
    {
        [Required]
        public int Id{get;set;}
        [Required]
        public string Content {get;set;}
        public string Login{get;set;}
    }
}