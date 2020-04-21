using System.Collections.Generic;
using Web.Models.AutoMapperDTO;

namespace Web.Models.Models
{
    public class PaginationPostResult
    {
        public List<PostDTO> Posts{get;set;}
        public bool isEnd{get;set;}
    }
}