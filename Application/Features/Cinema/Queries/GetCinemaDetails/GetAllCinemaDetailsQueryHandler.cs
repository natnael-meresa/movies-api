using Application.Contracts.Persistence;
using Application.DTOs.Cinema;
using Application.Exceptions;
using AutoMapper;
using MediatR;


namespace Application.Features.Cinema.Queries.GetCinemaDetails;

public class GetCinemaDetailsQueryHandler : IRequestHandler<GetCinemaDetailsQuery, CinemaDto>
{
    private readonly ICinemaRepository _cinemaRepository;
    private readonly IMapper _mapper;
    
    public GetCinemaDetailsQueryHandler(ICinemaRepository cinemaRepository, IMapper mapper)
    {
        _cinemaRepository = cinemaRepository;
        _mapper = mapper;
    }
    
    public async Task<CinemaDto> Handle(GetCinemaDetailsQuery request, CancellationToken cancellationToken)
    {

        var cinema = await _cinemaRepository.GetAsync(request.Id);

        if (cinema == null)
            throw new NotFoundException(nameof(Domain.Entities.Cinema), request.Id);
      

        var cinemaDto = _mapper.Map<CinemaDto>(cinema);
        
        return cinemaDto;
    }
}