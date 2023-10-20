using Core.Entities;
namespace API.Dtos;

public class DetailIncidenceDto
{
    public int Id_DetailIncidence { get; set; }
    public int Id_Peripheral { get; set; }
    public int Id_TypeIncidence { get; set; }
    public int Id_LevelIncidence { get; set; }
    public int Id_State { get; set; }
    public string ? Description_DetailIncidence { get; set; }
}