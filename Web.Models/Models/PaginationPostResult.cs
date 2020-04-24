using System.Collections.Generic;
using Web.Models.AutoMapperDTO;

namespace Web.Models.Models
{
    public class PaginationResult<T>
    {
        public List<T> Result{get;set;}
        public bool isEnd{get;set;}
    }
}