using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Cinema.Commands.DeleteCinema;

public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand, Unit>
{
    private readonly ICinemaRepository _cinemaRepository;
    
    public DeleteCinemaCommandHandler(ICinemaRepository cinemaRepository)
    {
        _cinemaRepository = cinemaRepository;
    }
    
    public async Task<Unit> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
    {

        var cinemaToDelete = await _cinemaRepository.GetAsync(request.Id);

        if (cinemaToDelete == null)
            throw new NotFoundException(nameof(Domain.Entities.Cinema), request.Id);
      

        await _cinemaRepository.DeleteAsync(cinemaToDelete);
        
        return Unit.Value;
    }
}