using MediatR;

namespace Application.Features.Movie.Commands.DeleteMovie;

public class DeleteMovieCommand : IRequest<Unit>
{
    public int Id { get; set; }

}