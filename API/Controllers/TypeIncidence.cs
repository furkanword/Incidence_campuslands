using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class TypeIncidenceController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TypeIncidenceController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TypeIncidence>>> Get()
    {
        var TypeIncidence = await unitofwork.TypeIncidence.GetAllAsync();
        return Ok(TypeIncidence);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<TypeIncidenceDto>> Get()
    {
        var TypeIncidence = await unitofwork.TypeIncidences.GetAllAsync();
        return this.mapper.Map<List<TypeIncidenceDto>>(TypeIncidence);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var TypeIncidence = await unitofwork.TypeIncidences.GetByIdAsync(id);
        return Ok(TypeIncidence);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypeIncidence>> Post(TypeIncidence TypeIncidence){
        this.unitofwork.TypeIncidences.Add(TypeIncidence);
        await unitofwork.SaveAsync();
        if(TypeIncidence == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= TypeIncidence.Id_TypeIncidence}, TypeIncidence);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypeIncidence>> Put(int id, [FromBody]TypeIncidence TypeIncidence){
        if(TypeIncidence == null)
            return NotFound();
        unitofwork.TypeIncidences.Update(TypeIncidence);
        await unitofwork.SaveAsync();
        return TypeIncidence;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var TypeIncidence = await unitofwork.TypeIncidences.GetByIdAsync(id);
        if(TypeIncidence == null){
            return NotFound();
        }
        unitofwork.TypeIncidences.Remove(TypeIncidence);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}