using System.Collections.Generic;
using Web.Models.Entity;

namespace Web.Models.Interfaces.Stores
{
    public interface ISubscribersDbStore
    {
        void SubscribeToUser(string to, string who);
        bool UserIsSubscribed(string to, string who);
        void UnSubscribeUser(string to, string who);
        public List<User> GetSubscribers(string login,int page, int pageSize);
        public List<User> GetSubscribed(string login,int page, int pageSize);
        public int CountSubscribers(string login);
        public int CountSubscribed(string login);


    }
}