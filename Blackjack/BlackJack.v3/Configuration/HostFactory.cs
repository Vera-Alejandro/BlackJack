using Blackjack.Data.Configuration;
using Blackjack.GamePlay.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlackJack.v3.Configuration
{
    public static class HostFactory
    {
        public static IHost Create()
        {
            var hostBuilder = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(StartUp.ConfigureAppConfiguration)
                .ConfigureServices(StartUp.ConfigureServices);

            return hostBuilder.Build();
        }
    }

    public static class StartUp
    {
        public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
            => ConfigureServices(context.Configuration, services);

        public static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddConfigurationSettings(configuration);

            services.InjectDependencies(configuration);

            RegisterViewModels(services);
        }

        private static void RegisterViewModels(IServiceCollection services)
        {
            services.AddSingleton<ViewModels.MainWindowViewModel>();
        }
    }

    public static class SettingsServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurationSettings(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services;
        }
    }

    public static class DependencyInjector
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.InjectDataAccess(config);
            services.InjectUseCases(config);
        }
    }
}