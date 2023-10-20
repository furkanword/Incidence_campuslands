using Core.Entities;
namespace API.Dtos;

public class UsersDto
{
    public int Id_User { get; set; }
    
    public string ? Name_User { get; set; }
    public string ? Lastname_User { get; set; }
    public string ? Address_User { get; set; }
    public int Id_DocumentType { get; set; }
    public int Id_Rol { get; set; }
}