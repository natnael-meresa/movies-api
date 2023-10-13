using Application.DTOs.Movie;
using MediatR;

namespace Application.Features.Movie.Commands.CreateMovie;

public class CreateMovieCommand : IRequest<MovieDto>
{
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public string? Description { get; set; }
    public int ReleaseYear { get; set; }
}