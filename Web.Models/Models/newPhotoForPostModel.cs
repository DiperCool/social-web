using Microsoft.AspNetCore.Http;

namespace Web.Models.Models
{
    public class newPhotoForPostModel
    {
        public IFormFileCollection imgs{get;set;}
        public int idPost{get;set;}
    }
}