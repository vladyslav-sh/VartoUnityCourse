using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console.Cli;
using Tools;

namespace VartoUnityCourse
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config => config.AddUserSecrets<Program>())
                .ConfigureServices((context, serviceCollection) => ConfigureServices(context.Configuration, serviceCollection))
                .Build();

            await host.Services.GetRequiredService<App>().RunAsync(args);
        }

        static void ConfigureServices(IConfiguration config, IServiceCollection services)
        {
            services.AddSingleton(config);
            services.AddOptions();

            services.AddSingleton<App>();
            
            services.AddSingleton<ITypeRegistrar>(_ => new App.ServiceCollectionRegistrar(services));
        }
    }
}
