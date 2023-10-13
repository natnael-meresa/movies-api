using Application.DTOs.Movie;
using MediatR;

namespace Application.Features.Movie.Queries.GetMovieDetails;

public record GetMovieDetailsQuery(int Id) : IRequest<MovieDetailsDto>;