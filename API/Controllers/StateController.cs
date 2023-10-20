using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class StateController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public StateController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<State>>> Get()
    {
        var state = await unitofwork.State.GetAllAsync();
        return Ok(state);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<StateDto>> Get()
    {
        var state = await unitofwork.States.GetAllAsync();
        return this.mapper.Map<List<StateDto>>(state);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var state = await unitofwork.States.GetByIdAsync(id);
        return Ok(state);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<State>> Post(State state){
        this.unitofwork.States.Add(state);
        await unitofwork.SaveAsync();
        if(state == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= state.Id_State}, state);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<State>> Put(int id, [FromBody]State state){
        if(state == null)
            return NotFound();
        unitofwork.States.Update(state);
        await unitofwork.SaveAsync();
        return state;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var state = await unitofwork.States.GetByIdAsync(id);
        if(state == null){
            return NotFound();
        }
        unitofwork.States.Remove(state);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}