using System.Collections.Generic;
using Web.Models.AutoMapperDTO;
using Web.Models.Models;

namespace Web.Models.Interfaces.Domains
{
    public interface ISearchUsers
    {
        PaginationResult<UserDTO> GetUserWithContains(string contains, int page);
    }
}