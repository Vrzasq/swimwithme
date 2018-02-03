using api.commons;
using api.repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace api.tools
{
    public static class MyExtensions
    {
        public static bool ToBool(this string str)
        {
            if (str == "1")
                return true;
            return false;
        }

        public static IWebHost InitInMemoryDB(this IWebHost webhost)
        {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ITrainingTaskRepository>();
                MemoryDataLoader.LoadTestDataViaRepo(repo);

            }
            return webhost;
        }
    }
}