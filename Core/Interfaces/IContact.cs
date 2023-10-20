
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IContact
{
    Task<Contact> GetByIdAsync(int id);
    Task<IEnumerable<Contact>> GetAllAsync();
    IEnumerable<Contact>  Find(Expression<Func<Contact, bool>> expression);
    void Add(Contact entity);
    void AddRange(IEnumerable<Contact> entities);
    void Remove(Contact entity);
    void RemoveRange(IEnumerable<Contact> entities);
    void Update(Contact entity);


}
