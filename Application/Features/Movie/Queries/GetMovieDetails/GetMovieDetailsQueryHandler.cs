using Application.Contracts.Persistence;
using Application.DTOs.Movie;
using Application.Exceptions;
using AutoMapper;
using MediatR;


namespace Application.Features.Movie.Queries.GetMovieDetails;

public class GetMovieDetailsQueryHandler : IRequestHandler<GetMovieDetailsQuery, MovieDetailsDto>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;
    
    public GetMovieDetailsQueryHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    
    public async Task<MovieDetailsDto> Handle(GetMovieDetailsQuery request, CancellationToken cancellationToken)
    {

        var movie = await _movieRepository.GetAsync(request.Id);

        if (movie == null)
            throw new NotFoundException(nameof(Domain.Entities.Movie), request.Id);
      

        var movieDto = _mapper.Map<MovieDetailsDto>(movie);
        return movieDto;
    }
}