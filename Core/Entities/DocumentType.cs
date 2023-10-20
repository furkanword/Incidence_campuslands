using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class DocumentType
{
    [Key]
    public int Id_DocumentType { get; set; }
    public string ?Name_DocumentType { get; set; }
    public ICollection<User> ?Users { get; set; }
    public Contact ? Contact { get; set; }
    public string ?Abbreviation_DocumentType { get; set; }
}