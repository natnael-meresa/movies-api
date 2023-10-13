using Application.Contracts.Persistence;
using Application.DTOs.Movie;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Movie.Commands.CreateMovie;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieDto>
{
    private readonly IMapper _mapper;
    private readonly IMovieRepository _movieRepository;
    
    public CreateMovieCommandHandler(IMapper mapper, IMovieRepository movieRepository)
    {
        _mapper = mapper;
        _movieRepository = movieRepository;
    }
    
    public async Task<MovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateMovieCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Movie Request", validationResult);
        
        var movie = _mapper.Map<Domain.Entities.Movie>(request);

        await _movieRepository.CreateAsync(movie);
  
        var movieDto = _mapper.Map<MovieDto>(movie);
        
        return movieDto;
    
    }
}