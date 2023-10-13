using Application.DTOs.Movie;
using MediatR;

namespace Application.Features.Movie.Commands.UpdateMovie;

public class UpdateMovieCommand : IRequest<MovieDto>
{
    public int Id {get; set;}
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public string? Description { get; set; }
    public int ReleaseYear { get; set; }
}