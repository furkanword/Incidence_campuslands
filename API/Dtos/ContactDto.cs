using Core.Entities;
namespace API.Dtos;

public class ContactDto 
{
    public int ? Id_Contact { get; set; }
    public int ? Id_User { get; set; }
    public int ? Id_ContactType { get; set; }
    public int ? Id_CategoryContact { get; set; }
    public string ? Description_Contact { get; set; }
}