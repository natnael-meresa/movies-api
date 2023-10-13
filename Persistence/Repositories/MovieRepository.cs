using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.Configureations;

namespace Persistence.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(MoviesAPIDatabaseContext context) : base(context)
    {
        
    }
}