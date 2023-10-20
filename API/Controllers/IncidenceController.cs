using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class IncidenceController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public IncidenceController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Incidence>>> Get()
    {
        var incidence = await unitofwork.Incidence.GetAllAsync();
        return Ok(incidence);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<IncidenceDto>> Get()
    {
        var incidence = await unitofwork.Incidences.GetAllAsync();
        return this.mapper.Map<List<IncidenceDto>>(incidence);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var incidence = await unitofwork.Incidences.GetByIdAsync(id);
        return Ok(incidence);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidence>> Post(Incidence incidence){
        this.unitofwork.Incidences.Add(incidence);
        await unitofwork.SaveAsync();
        if(incidence == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= incidence.Id_Incidence}, incidence);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidence>> Put(int id, [FromBody]Incidence incidence){
        if(incidence == null)
            return NotFound();
        unitofwork.Incidences.Update(incidence);
        await unitofwork.SaveAsync();
        return incidence;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var incidence = await unitofwork.Incidences.GetByIdAsync(id);
        if(incidence == null){
            return NotFound();
        }
        unitofwork.Incidences.Remove(incidence);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}