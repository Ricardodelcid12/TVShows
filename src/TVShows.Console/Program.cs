using Microsoft.Extensions.DependencyInjection;
using TVShows.Console;

namespace TVShows
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Dependency injection Configuration.
            var serviceProvider = ServiceConfiguration.Configure();

            //Entry point service.
            var appService = serviceProvider.GetRequiredService<AppService>();

            //Run application.
            await appService.Run();
        }
    }
}