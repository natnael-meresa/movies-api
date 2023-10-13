using Application.Contracts.Persistence;
using Application.DTOs.Cinema;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Cinema.Commands.CreateCinema;

public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, CinemaDto>
{
    private readonly IMapper _mapper;
    private readonly ICinemaRepository _cinemaRepository;
    
    public CreateCinemaCommandHandler(IMapper mapper, ICinemaRepository cinemaRepository)
    {
        _mapper = mapper;
        _cinemaRepository = cinemaRepository;
    }
    
    public async Task<CinemaDto> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCinemaCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Cinema Request", validationResult);
        
        var cinema = _mapper.Map<Domain.Entities.Cinema>(request);

        await _cinemaRepository.UdateAsync(cinema);

        var CinemaDto = _mapper.Map<CinemaDto>(cinema);
        
        return CinemaDto;
    }
}