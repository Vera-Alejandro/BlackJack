using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blackjack.GamePlay.Configuration;

public static class UseCasesInjector
{
    public static void InjectUseCases(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<GameInstance>();
    }
}
