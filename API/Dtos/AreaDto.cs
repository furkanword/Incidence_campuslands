using Core.Entities;
namespace API.Dtos;

public class AreaDto : AreasDto
{
    
    public List<PlacesDto>? Lugares { get; set; }
    public string ? Incidente { get; set; }
    public string ? Descripcion { get; set; }
}