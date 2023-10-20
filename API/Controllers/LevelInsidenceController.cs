using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class LevelIncidenceController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public LevelIncidenceController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LevelIncidence>>> Get()
    {
        var incidence = await unitofwork.LevelIncidence.GetAllAsync();
        return Ok(incidence);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<LevelIncidenceDto>> Get()
    {
        var levelIncidence = await unitofwork.LevelIncidences.GetAllAsync();
        return this.mapper.Map<List<LevelIncidenceDto>>(levelIncidence);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var levelIncidence = await unitofwork.LevelIncidences.GetByIdAsync(id);
        return Ok(levelIncidence);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LevelIncidence>> Post(LevelIncidence levelIncidence){
        this.unitofwork.LevelIncidences.Add(levelIncidence);
        await unitofwork.SaveAsync();
        if(levelIncidence == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= levelIncidence.Id_LevelIncidence}, levelIncidence);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LevelIncidence>> Put(int id, [FromBody]LevelIncidence levelIncidence){
        if(levelIncidence == null)
            return NotFound();
        unitofwork.LevelIncidences.Update(levelIncidence);
        await unitofwork.SaveAsync();
        return levelIncidence;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var levelIncidence = await unitofwork.LevelIncidences.GetByIdAsync(id);
        if(levelIncidence == null){
            return NotFound();
        }
        unitofwork.LevelIncidences.Remove(levelIncidence);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}