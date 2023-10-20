using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class AreaController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public AreaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Area>>> Get()
    {
        var area = await unitofwork.Area.GetAllAsync();
        return Ok(area);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<AreasDto>> Get()
    {
        var area = await unitofwork.Areas.GetAllAsync();
        return this.mapper.Map<List<AreasDto>>(area);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<AreasDto>>> Get11([FromQuery] Params areaParams)
    {
        var (totalRegistros, registros) = await unitofwork.Areas.GetAllAsync(
            areaParams.PageIndex,
            areaParams.PageSize,
            areaParams.Search
        );
        var listAreasDto = mapper.Map<List<AreasDto>>(registros);
        return new Pager<AreasDto>(
            listAreasDto,
            totalRegistros,
            areaParams.PageIndex,
            areaParams.PageSize,
            areaParams.Search
        );
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<AreaDto>> Get(int id)
    {
        var area = await unitofwork.Areas.GetByIdAsync(id);
        return this.mapper.Map<List<AreaDto>>(area);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(Area area){
        this.unitofwork.Areas.Add(area);
        await unitofwork.SaveAsync();
        if(area == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= area.Id_Area}, area);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area area){
        if(area == null)
            return NotFound();
        unitofwork.Areas.Update(area);
        await unitofwork.SaveAsync();
        return area;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var area = await unitofwork.Areas.GetByIdAsync(id);
        if(area == null){
            return NotFound();
        }
        unitofwork.Areas.Remove(area);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}