using System;

namespace Web.Infrastructure.Pagination
{

    public class Pagination
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
 
        public Pagination(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
        public bool HasNextPage
        {
            get
            {
                return (PageNumber <= TotalPages);
            }
        }
        public bool HasNextPageOne{
            get{
                return (PageNumber+1<=TotalPages);
            }
        }    
    }
}