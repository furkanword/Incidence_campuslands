using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class DetailIncidenceController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public DetailIncidenceController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetailIncidence>>> Get()
    {
        var detailincidence = await unitofwork.DetailIncidence.GetAllAsync();
        return Ok(detailincidence);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<DetailIncidenceDto>> Get()
    {
        var detailincidence = await unitofwork.DetailIncidences.GetAllAsync();
        return this.mapper.Map<List<DetailIncidenceDto>>(detailincidence);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var detailincidence = await unitofwork.DetailIncidences.GetByIdAsync(id);
        return Ok(detailincidence);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetailIncidence>> Post(DetailIncidence detailincidence){
        this.unitofwork.DetailIncidences.Add(detailincidence);
        await unitofwork.SaveAsync();
        if(detailincidence == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= detailincidence.Id_DetailIncidence}, detailincidence);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetailIncidence>> Put(int id, [FromBody]DetailIncidence detailincidence){
        if(detailincidence == null)
            return NotFound();
        unitofwork.DetailIncidences.Update(detailincidence);
        await unitofwork.SaveAsync();
        return detailincidence;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var detailincidence = await unitofwork.DetailIncidences.GetByIdAsync(id);
        if(detailincidence == null){
            return NotFound();
        }
        unitofwork.DetailIncidences.Remove(detailincidence);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}