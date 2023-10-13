using MediatR;

namespace Application.Features.Cinema.Commands.DeleteCinema;

public class DeleteCinemaCommand : IRequest<Unit>
{
    public int Id { get; set; }
}