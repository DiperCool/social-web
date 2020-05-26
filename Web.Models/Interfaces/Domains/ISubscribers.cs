using System.Collections.Generic;
using Web.Models.AutoMapperDTO;
using Web.Models.Entity;
using Web.Models.Models;

namespace Web.Models.Interfaces.Domains
{
    public interface ISubscribers
    {
        void SubscribeToUser(string to, string who);
        void UnSubscribeUser(string to, string who);
        PaginationResult<UserDTO> GetSubscribers(string login,int page);
        PaginationResult<UserDTO> GetSubscribed(string login, int page);
        bool UserIsSubscribed(string to,string who);
    }
}