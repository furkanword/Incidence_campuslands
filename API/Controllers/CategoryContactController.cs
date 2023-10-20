using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class CategoryContactController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CategoryContactController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoryContact>>> Get()
    {
        var categorycontact = await unitofwork.CategoryContact.GetAllAsync();
        return Ok(categorycontact);
    } */
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<CategoryContactDto>> Get()
    {
        var categorycontact = await unitofwork.CategoryContacts.GetAllAsync();
        return this.mapper.Map<List<CategoryContactDto>>(categorycontact);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var categorycontact = await unitofwork.CategoryContacts.GetByIdAsync(id);
        return Ok(categorycontact);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryContact>> Post(CategoryContact categorycontact){
        this.unitofwork.CategoryContacts.Add(categorycontact);
        await unitofwork.SaveAsync();
        if(categorycontact == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= categorycontact.Id_CategoryContact}, categorycontact);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryContact>> Put(int id, [FromBody]CategoryContact categorycontact){
        if(categorycontact == null)
            return NotFound();
        unitofwork.CategoryContacts.Update(categorycontact);
        await unitofwork.SaveAsync();
        return categorycontact;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var categorycontact = await unitofwork.CategoryContacts.GetByIdAsync(id);
        if(categorycontact == null){
            return NotFound();
        }
        unitofwork.CategoryContacts.Remove(categorycontact);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}