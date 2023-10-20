using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class PlaceController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PlaceController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Place>>> Get()
    {
        var place = await unitofwork.Place.GetAllAsync();
        return Ok(place);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<PlaceDto>> Get()
    {
        var place = await unitofwork.Places.GetAllAsync();
        return this.mapper.Map<List<PlaceDto>>(place);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var place = await unitofwork.Places.GetByIdAsync(id);
        return Ok(place);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Place>> Post(Place place){
        this.unitofwork.Places.Add(place);
        await unitofwork.SaveAsync();
        if(place == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= place.Id_Place}, place);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Place>> Put(int id, [FromBody]Place place){
        if(place == null)
            return NotFound();
        unitofwork.Places.Update(place);
        await unitofwork.SaveAsync();
        return place;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var place = await unitofwork.Places.GetByIdAsync(id);
        if(place == null){
            return NotFound();
        }
        unitofwork.Places.Remove(place);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}