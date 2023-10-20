using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class ContactController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ContactController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Contact>>> Get()
    {
        var contact = await unitofwork.Contact.GetAllAsync();
        return Ok(contact);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<ContactDto>> Get()
    {
        var contact = await unitofwork.Contacts.GetAllAsync();
        return this.mapper.Map<List<ContactDto>>(contact);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var contact = await unitofwork.Contacts.GetByIdAsync(id);
        return Ok(contact);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contact>> Post(Contact contact){
        this.unitofwork.Contacts.Add(contact);
        await unitofwork.SaveAsync();
        if(contact == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= contact.Id_Contact}, contact);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contact>> Put(int id, [FromBody]Contact contact){
        if(contact == null)
            return NotFound();
        unitofwork.Contacts.Update(contact);
        await unitofwork.SaveAsync();
        return contact;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var contact = await unitofwork.Contacts.GetByIdAsync(id);
        if(contact == null){
            return NotFound();
        }
        unitofwork.Contacts.Remove(contact);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}