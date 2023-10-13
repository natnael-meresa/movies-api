using Application.DTOs.Cinema;
using MediatR;

namespace Application.Features.Cinema.Queries.GetAllCinemas;

public record GetAllCinemasQuery : IRequest<List<CinemaDto>>;