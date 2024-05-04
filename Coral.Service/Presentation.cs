using Coral.Service.Commons.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Coral.Service;

public static class Presentation
{
    public static IServiceCollection AddCoralPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<ProblemDetailsFactory, CoralProblemDetailsFactory>();
        return services;
    }
}
