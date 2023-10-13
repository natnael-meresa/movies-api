using Application.Contracts.Persistence;
using Application.DTOs.Movie;
using AutoMapper;
using MediatR;


namespace Application.Features.Movie.Queries.GetAllMovies;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieDto>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;
    
    public GetAllMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    
    public async Task<List<MovieDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {

        var movie = await _movieRepository.GetAllAsync();

        

        var movieDto = _mapper.Map<List<MovieDto>>(movie);

        return movieDto;
    }
}