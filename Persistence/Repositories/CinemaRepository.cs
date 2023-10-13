using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.Configureations;

namespace Persistence.Repositories;

public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
{
    public CinemaRepository(MoviesAPIDatabaseContext context) : base(context)
    {
        
    }
}