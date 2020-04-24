using System.ComponentModel.DataAnnotations;

namespace Web.Models.Models
{
    public class CommentModel
    {
        [Required(ErrorMessage="Сообщение не должно быть пустым")]
        public string Content{get;set;}
        public string To{get;set;}
        public string Login{get;set;}
    }
}