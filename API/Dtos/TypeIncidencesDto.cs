using Core.Entities;
namespace API.Dtos;

public class TypeIncidencesDto
{
    public int Id_TypeIncidence { get; set; }
    public string ?Name_TypeIncidence { get; set; }
    public string ?Description_TypeIncidence { get; set; }
}