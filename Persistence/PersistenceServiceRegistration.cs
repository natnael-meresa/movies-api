using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Configureations;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersitenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddDbContext<MoviesAPIDatabaseContext>(options => {
        //     options.UseNpgsql(configuration.GetConnectionString("MoviesDatabaseConnectionString"));
        // });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<ICinemaRepository, CinemaRepository>();

        return services;
    }
}
