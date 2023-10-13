using Application.Contracts.Persistence;
using Application.DTOs.Cinema;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Cinema.Commands.UpdateCinema;

public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, CinemaDto>
{
    private readonly IMapper _mapper;
    private readonly ICinemaRepository _cinemaRepository;
    
    public UpdateCinemaCommandHandler(IMapper mapper, ICinemaRepository cinemaRepository)
    {
        _mapper = mapper;
        _cinemaRepository = cinemaRepository;
    }
    
    public async Task<CinemaDto> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCinemaCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Cinema Request", validationResult);
        
        var cinema = _mapper.Map<Domain.Entities.Cinema>(request);

        await _cinemaRepository.UdateAsync(cinema);

        var CinemaDto = _mapper.Map<CinemaDto>(cinema);
        
        return CinemaDto;
    }
}