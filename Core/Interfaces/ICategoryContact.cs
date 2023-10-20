
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface ICategoryContact
{
    //Interface
    Task<CategoryContact> GetByIdAsync(int id);
    Task<IEnumerable<CategoryContact>> GetAllAsync();
    IEnumerable<CategoryContact>  Find(Expression<Func<CategoryContact, bool>> expression);
    void Add(CategoryContact entity);
    void AddRange(IEnumerable<CategoryContact> entities);
    void Remove(CategoryContact entity);
    void RemoveRange(IEnumerable<CategoryContact> entities);
    void Update(CategoryContact entity);


}
