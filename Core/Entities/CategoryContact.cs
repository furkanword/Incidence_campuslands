using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class CategoryContact
{
    [Key]
    public int Id_CategoryContact { get; set; }
    public Contact ? Contact { get; set; }
    public int Id_Category { get; set; }
    public string ?Name_CategoryContact { get; set; }
     public ICollection<Contact> ?Contacts { get; set; }
}