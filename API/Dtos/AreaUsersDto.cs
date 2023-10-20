using Core.Entities;
namespace API.Dtos;

public class AreaUsersDto
{
    public int ? Id_AreaUser { get; set; }
    public int ? Id_Area { get; set; }
    public int ? Id_User { get; set; }
}