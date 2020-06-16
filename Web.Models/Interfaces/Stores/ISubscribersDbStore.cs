using System.Collections.Generic;
using Web.Models.Entity;
using Web.Models.EntityModels;

namespace Web.Models.Interfaces.Stores
{
    public interface ISubscribersDbStore
    {
        void SubscribeToUser(string to, string who);
        bool UserIsSubscribed(string to, string who);
        void UnSubscribeUser(string to, string who);
        List<SubscriberEntity> GetSubscribers(string login,int page, int pageSize);
        List<SubscriberEntity> GetSubscribed(string login,int page, int pageSize);
        int CountSubscribers(string login);
        int CountSubscribed(string login);


    }
}