using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class PeripheralController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PeripheralController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Peripheral>>> Get()
    {
        var peripheral = await unitofwork.Peripheral.GetAllAsync();
        return Ok(peripheral);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<PeripheralDto>> Get()
    {
        var peripheral = await unitofwork.Peripherals.GetAllAsync();
        return this.mapper.Map<List<PeripheralDto>>(peripheral);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var peripheral = await unitofwork.Peripherals.GetByIdAsync(id);
        return Ok(peripheral);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Peripheral>> Post(Peripheral peripheral){
        this.unitofwork.Peripherals.Add(peripheral);
        await unitofwork.SaveAsync();
        if(peripheral == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= peripheral.Id_Peripheral}, peripheral);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Peripheral>> Put(int id, [FromBody]Peripheral peripheral){
        if(peripheral == null)
            return NotFound();
        unitofwork.Peripherals.Update(peripheral);
        await unitofwork.SaveAsync();
        return peripheral;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var peripheral = await unitofwork.Peripherals.GetByIdAsync(id);
        if(peripheral == null){
            return NotFound();
        }
        unitofwork.Peripherals.Remove(peripheral);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}