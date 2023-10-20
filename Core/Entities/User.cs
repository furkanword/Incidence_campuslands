using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class User
{
    [Key]
    public int Id_User { get; set; }
    public ICollection<Contact> ?Contacts { get; set; }
    public ICollection<AreaUser> ?AreaUsers { get; set; }
    public ICollection<Incidence> ?Incidences { get; set; }
    
    public string ?Name_User { get; set; }
    public string ?Lastname_User { get; set; }
    public string ?Address_User { get; set; }
    public int Id_DocumentType { get; set; }
    public DocumentType ? DocumentType { get; set; }

    public int Id_Rol { get; set; }
    public Rol ? Rol { get; set; }
}