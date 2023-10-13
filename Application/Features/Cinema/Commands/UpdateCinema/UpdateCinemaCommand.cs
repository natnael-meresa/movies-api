using Application.DTOs.Cinema;
using MediatR;

namespace Application.Features.Cinema.Commands.UpdateCinema;

public class UpdateCinemaCommand : IRequest<CinemaDto>
{
    public int Id { get; set;}
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? PhoneNumber { get; set; }
}