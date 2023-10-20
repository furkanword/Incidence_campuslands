using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class RolController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public RolController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Rol>>> Get()
    {
        var rol = await unitofwork.Rol.GetAllAsync();
        return Ok(rol);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<RolDto>> Get()
    {
        var rol = await unitofwork.Rols.GetAllAsync();
        return this.mapper.Map<List<RolDto>>(rol);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var rol = await unitofwork.Rols.GetByIdAsync(id);
        return Ok(rol);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Post(Rol rol){
        this.unitofwork.Rols.Add(rol);
        await unitofwork.SaveAsync();
        if(rol == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= rol.Id_Rol}, rol);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Put(int id, [FromBody]Rol rol){
        if(rol == null)
            return NotFound();
        unitofwork.Rols.Update(rol);
        await unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var rol = await unitofwork.Rols.GetByIdAsync(id);
        if(rol == null){
            return NotFound();
        }
        unitofwork.Rols.Remove(rol);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}