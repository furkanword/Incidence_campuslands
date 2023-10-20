using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class UserController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public UserController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        var user = await unitofwork.User.GetAllAsync();
        return Ok(user);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<UserDto>> Get()
    {
        var user = await unitofwork.Users.GetAllAsync();
        return this.mapper.Map<List<UserDto>>(user);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var user = await unitofwork.Users.GetByIdAsync(id);
        return Ok(user);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> Post(User user){
        this.unitofwork.Users.Add(user);
        await unitofwork.SaveAsync();
        if(user == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= user.Id_User}, user);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> Put(int id, [FromBody]User user){
        if(user == null)
            return NotFound();
        unitofwork.Users.Update(user);
        await unitofwork.SaveAsync();
        return user;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var user = await unitofwork.Users.GetByIdAsync(id);
        if(user == null){
            return NotFound();
        }
        unitofwork.Users.Remove(user);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}