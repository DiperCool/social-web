namespace Web.Models.AutoMapperDTO
{
    public class CommentDTO
    {
        public int Id{get;set;}
        public string To { get; set; }
        public string Content{get;set;}
        public UserDTO Author{get;set;}
    }
}