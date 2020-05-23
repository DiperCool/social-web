using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Models.Interfaces.Domains;

namespace Web.Domain
{
    public static class StoreCollectionServices
    {
        public static IServiceCollection AddDomainsCollection(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IAuth, Auth.Auth>()
                .AddTransient<IAccount, Account.Account>()
                .AddTransient<IPost, Posts.Posts>()
                .AddTransient<IComments, Comments.Comments>()
                .AddTransient<ISearchUsers, SearchUsers.SearchUsers>()
                .AddTransient<ISubscribers, Subscribers.Subscribers>();
        }
    }
}