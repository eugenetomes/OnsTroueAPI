using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace OnsTrou.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly);
        });
        services.AddValidatorsFromAssembly(AssemblyReference.Assembly);

        return services;
    }
}
