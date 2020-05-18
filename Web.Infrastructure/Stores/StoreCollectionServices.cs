using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Models.Interfaces;
using Web.Models.Interfaces.Stores;

namespace Web.Infrastructure.Stores
{
    public static class StoreCollectionServices
    {
        public static IServiceCollection AddStoresCollection(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IAuthDbStore, AuthDbStore>()
                .AddTransient<IProfileDbStore, ProfileDbStore>()
                .AddTransient<IPostDbStore, PostDbStore>()
                .AddTransient<ICommentStore, CommentDbStore>();

        }
    }
}