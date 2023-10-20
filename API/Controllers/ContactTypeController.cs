using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class ContactTypeController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ContactTypeController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactType>>> Get()
    {
        var contactType = await unitofwork.ContactType.GetAllAsync();
        return Ok(contactType);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<ContactTypeDto>> Get()
    {
        var contactType = await unitofwork.ContactTypes.GetAllAsync();
        return this.mapper.Map<List<ContactTypeDto>>(contactType);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var contactType = await unitofwork.ContactTypes.GetByIdAsync(id);
        return Ok(contactType);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactType>> Post(ContactType contactType){
        this.unitofwork.ContactTypes.Add(contactType);
        await unitofwork.SaveAsync();
        if(contactType == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= contactType.Id_ContactType}, contactType);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactType>> Put(int id, [FromBody]ContactType contactType){
        if(contactType == null)
            return NotFound();
        unitofwork.ContactTypes.Update(contactType);
        await unitofwork.SaveAsync();
        return contactType;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var contactType = await unitofwork.ContactTypes.GetByIdAsync(id);
        if(contactType == null){
            return NotFound();
        }
        unitofwork.ContactTypes.Remove(contactType);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}