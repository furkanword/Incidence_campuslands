using Core.Entities;
namespace API.Dtos;

public class ContactsTypeDto
{
    public int ? Id_ContactType { get; set; }
    public string ? Name_ContactType { get; set; }
    public string ? Description_ContactType { get; set; }
}