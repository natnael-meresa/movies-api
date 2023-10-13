using Application.DTOs.Movie;
using MediatR;

namespace Application.Features.Movie.Queries.GetAllMovies;

public record GetAllMoviesQuery : IRequest<List<MovieDto>>;