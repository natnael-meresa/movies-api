using Application.DTOs.Movie;
using Application.Features.Movie.Commands.CreateMovie;
using Application.Features.Movie.Commands.UpdateMovie;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<MovieDto, Movie>().ReverseMap();
        CreateMap<CreateMovieCommand, Movie>();
        CreateMap<UpdateMovieCommand, Movie>();
        CreateMap<Movie, MovieDetailsDto>();
    }
}
