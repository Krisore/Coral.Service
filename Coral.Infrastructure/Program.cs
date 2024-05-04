using Coral.Application.Commons.Repositories;
using Coral.Infrastructure.Persistent;
using Coral.Infrastructure.Persistent.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coral.Infrastructure;

public static class Program
{
    public static IServiceCollection AddCoralInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("Coral.Service")));


        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
}
