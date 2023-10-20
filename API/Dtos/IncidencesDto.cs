using Core.Entities;
namespace API.Dtos;

public class IncidencesDto
{
    public int Id_Incidence { get; set; }
    public int Id_User { get; set; }
    public int Id_State { get; set; }
    public int Id_Area { get; set; }
    public int Id_Place { get; set; }
    public DateTime Date { get; set; }
    public string ? Description_Incidence { get; set; }
}