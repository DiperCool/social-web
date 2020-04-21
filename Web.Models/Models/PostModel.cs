using Microsoft.AspNetCore.Http;

namespace Web.Models.Models
{
    public class PostModel
    {
        public string Description {get;set;}
        public IFormFileCollection Photos{get;set;}
    }
}