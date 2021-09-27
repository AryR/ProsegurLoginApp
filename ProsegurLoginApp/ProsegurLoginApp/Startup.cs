using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProsegurLoginApp.Services.API;
using ProsegurLoginApp.Services.Navigation;
using ProsegurLoginApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Essentials;

namespace ProsegurLoginApp
{
    public class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static App Init()
        {
            var a = Assembly.GetExecutingAssembly();
            var stream = a.GetManifestResourceStream("ProsegurLoginApp.appsettings.json");

            var host = new HostBuilder()
                        .ConfigureHostConfiguration(c =>
                        {
                            c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                            c.AddJsonStream(stream);
                        })
                        .ConfigureServices((c, x) =>
                        {
                            ConfigureServices(c, x);
                        })
                        .ConfigureLogging(l => l.AddSimpleConsole(options =>
                        {
                            options.IncludeScopes = true;
                            options.SingleLine = true;
                            options.TimestampFormat = "hh:mm:ss ";
                        }))
                        .Build();

            ServiceProvider = host.Services;

            return ServiceProvider.GetService<App>();
        }

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IApiService, ApiService>();

            services.AddTransient<LoginViewModel>();
            services.AddTransient<HomeViewModel>();

            services.AddSingleton<App>();
        }
    }
}
