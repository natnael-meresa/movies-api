using Application.DTOs.Movie;
using Application.Features.Movie.Commands.CreateMovie;
using Application.Features.Movie.Commands.DeleteMovie;
using Application.Features.Movie.Commands.UpdateMovie;
using Application.Features.Movie.Queries.GetAllMovies;
using Application.Features.Movie.Queries.GetMovieDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMediator _mediator;
    public MovieController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<List<MovieDto>> Get()
    {
        var result = await _mediator.Send(new GetAllMoviesQuery());
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDto>> Get(int id)
    {
        var result = await _mediator.Send(new GetMovieDetailsQuery(id));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovieDetailsDto>> Create(CreateMovieCommand movie)
    {
        var result = await _mediator.Send(movie);

        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<MovieDto>> Update(UpdateMovieCommand movie)
    {
        var result = await _mediator.Send(movie);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteMovieCommand {Id = id});

        return NoContent();
    }
}

