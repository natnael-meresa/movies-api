using Application.Contracts.Persistence;
using Application.DTOs.Cinema;
using AutoMapper;
using MediatR;


namespace Application.Features.Cinema.Queries.GetAllCinemas;

public class GetAllCinemasQueryHandler : IRequestHandler<GetAllCinemasQuery, List<CinemaDto>>
{
    private readonly ICinemaRepository _cinemaRepository;
    private readonly IMapper _mapper;
    
    public GetAllCinemasQueryHandler(ICinemaRepository cinemaRepository, IMapper mapper)
    {
        _cinemaRepository = cinemaRepository;
        _mapper = mapper;
    }
    
    public async Task<List<CinemaDto>> Handle(GetAllCinemasQuery request, CancellationToken cancellationToken)
    {

        var cinema = await _cinemaRepository.GetAllAsync();

        

        var cinemaDto = _mapper.Map<List<CinemaDto>>(cinema);

        return cinemaDto;
    }
}