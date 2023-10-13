using Application.DTOs.Cinema;
using Application.Features.Cinema.Commands.CreateCinema;
using Application.Features.Cinema.Commands.DeleteCinema;
using Application.Features.Cinema.Commands.UpdateCinema;
using Application.Features.Cinema.Queries.GetAllCinemas;
using Application.Features.Cinema.Queries.GetCinemaDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CinemaController : ControllerBase
{
    private readonly IMediator _mediator;
    public CinemaController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<List<CinemaDto>> Get()
    {
        var result = await _mediator.Send(new GetAllCinemasQuery());
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CinemaDto>> Get(int id)
    {
        var result = await _mediator.Send(new GetCinemaDetailsQuery(id));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CinemaDto>> Create(CreateCinemaCommand cinema)
    {
        var result = await _mediator.Send(cinema);

        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<CinemaDto>> Update(UpdateCinemaCommand cinema)
    {
        var result = await _mediator.Send(cinema);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCinemaCommand {Id = id});

        return NoContent();
    }
}

