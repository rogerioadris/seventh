using Microsoft.Extensions.DependencyInjection;

namespace Seventh.Desafio.Infra;

public static class ServiceInjector
{
    public static IServiceCollection AddInfraContext(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<SeventhContext>(options => options.UseSqlServer(connectionString));

        return AddRepositories(services);
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IServerRepository, ServerRepository>();
        return services;
    }
}
