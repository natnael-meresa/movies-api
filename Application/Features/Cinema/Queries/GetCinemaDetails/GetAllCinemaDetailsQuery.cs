using Application.DTOs.Cinema;
using MediatR;

namespace Application.Features.Cinema.Queries.GetCinemaDetails;

public record GetCinemaDetailsQuery(int Id) : IRequest<CinemaDto>;