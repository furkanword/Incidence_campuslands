using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class DocumentTypeController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public DocumentTypeController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DocumentType>>> Get()
    {
        var area = await unitofwork.DocumentType.GetAllAsync();
        return Ok(area);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<DocumentTypeDto>> Get()
    {
        var documentType = await unitofwork.DocumentTypes.GetAllAsync();
        return this.mapper.Map<List<DocumentTypeDto>>(documentType);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var documentType = await unitofwork.DocumentTypes.GetByIdAsync(id);
        return Ok(documentType);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentType>> Post(DocumentType documentType){
        this.unitofwork.DocumentTypes.Add(documentType);
        await unitofwork.SaveAsync();
        if(documentType == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= documentType.Id_DocumentType}, documentType);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentType>> Put(int id, [FromBody]DocumentType documentType){
        if(documentType == null)
            return NotFound();
        unitofwork.DocumentTypes.Update(documentType);
        await unitofwork.SaveAsync();
        return documentType;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var documentType = await unitofwork.DocumentTypes.GetByIdAsync(id);
        if(documentType == null){
            return NotFound();
        }
        unitofwork.DocumentTypes.Remove(documentType);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}