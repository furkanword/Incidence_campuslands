using Core.Entities;
namespace API.Dtos;

public class PlaceDto : PlacesDto
{
    public string ? Descripcion { get; set; }
    public AreasDto? Area { get; set; }
}