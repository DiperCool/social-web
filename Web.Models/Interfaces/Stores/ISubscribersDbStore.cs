using System.Collections.Generic;
using Web.Models.Entity;

namespace Web.Models.Interfaces.Stores
{
    public interface ISubscribersDbStore
    {
        void SubscribeToUser(string to, string who);
        bool UserIsSubscribed(string to, string who);
        void UnSubscribeUser(string to, string who);
        List<User> GetSubscribers(string login,int page, int pageSize);
        List<User> GetSubscribed(string login,int page, int pageSize);
        int CountSubscribers(string login);
        int CountSubscribed(string login);


    }
}