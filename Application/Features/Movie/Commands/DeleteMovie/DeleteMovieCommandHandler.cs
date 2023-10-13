using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Movie.Commands.DeleteMovie;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
{
    private readonly IMovieRepository _movieRepository;
    
    public DeleteMovieCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {

        var movieToDelete = await _movieRepository.GetAsync(request.Id);

        if (movieToDelete == null)
            throw new NotFoundException(nameof(Domain.Entities.Movie), request.Id);
      

        await _movieRepository.DeleteAsync(movieToDelete);
        
        return Unit.Value;
    }
}