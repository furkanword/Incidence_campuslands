using Core.Entities;
namespace API.Dtos;

public class CategoryContactDto 
{
    public int ? Id_CategoryContact { get; set; }
    public int ? Id_Category { get; set; }
    public string ? Name_CategoryContact { get; set; }
} 