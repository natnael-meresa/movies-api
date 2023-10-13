using Application.DTOs.Cinema;
using MediatR;

namespace Application.Features.Cinema.Commands.CreateCinema;

public class CreateCinemaCommand : IRequest<CinemaDto>
{
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? PhoneNumber { get; set; }
}