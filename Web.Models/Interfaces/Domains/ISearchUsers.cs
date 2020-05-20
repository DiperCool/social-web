using System.Collections.Generic;
using Web.Models.AutoMapperDTO;

namespace Web.Models.Interfaces.Domains
{
    public interface ISearchUsers
    {
        List<UserDTO> GetUserWithContains(string contains, int page);
    }
}