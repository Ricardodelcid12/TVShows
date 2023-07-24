using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TVShows.Application.Common.Interfaces;
using TVShows.Application.Services;
using TVShows.Domain.Repositories;
using TVShows.Infrastructure;
using TVShows.Infrastructure.Repositories;

namespace TVShows.Console
{
    /// <summary>
    /// Configure and register services that can be injected
    /// </summary>
    public static class ServiceConfiguration
    {
        public static IServiceProvider Configure()
        {

            IConfigurationRoot _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            services.AddDbContext<TVShowsDbContext>(opt =>
                opt.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            var assembly = AppDomain.CurrentDomain.Load("TVShows.Application");
            services.AddMediatR(assembly);

            //Add Scope to the main service to run the application
            services.AddSingleton<AppService>();

            //Add Scope to the TVShowHandler service.
            services.AddScoped<ITVShowInputHandlerService, TVShowInputHandlerService>();

            // ExceptionHandler service
            services.AddSingleton<ExceptionHandler>() 
                .AddLogging(builder =>
                {
                    builder.AddConsole();
                });

            //Register ITVShowService as transient
            services.AddTransient<ITVShowService, TVShowService>();
            services.AddTransient<ITVShowRepository, TVShowRepository>();

            return services.BuildServiceProvider();
        }
    }
}
