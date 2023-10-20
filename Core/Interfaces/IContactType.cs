
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IContactType
{
    //Interface
    Task<ContactType> GetByIdAsync(int id);
    Task<IEnumerable<ContactType>> GetAllAsync();
    IEnumerable<ContactType>  Find(Expression<Func<ContactType, bool>> expression);
    void Add(ContactType entity);
    void AddRange(IEnumerable<ContactType> entities);
    void Remove(ContactType entity);
    void RemoveRange(IEnumerable<ContactType> entities);
    void Update(ContactType entity);


}
