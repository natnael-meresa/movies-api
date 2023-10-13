using Application.DTOs.Cinema;
using Application.Features.Cinema.Commands.CreateCinema;
using Application.Features.Cinema.Commands.UpdateCinema;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CinemaDto, Cinema>().ReverseMap();
        CreateMap<CreateCinemaCommand, Cinema>();
        CreateMap<UpdateCinemaCommand, Cinema>();
    }
}
