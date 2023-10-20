
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IRol
{
    Task<Rol> GetByIdAsync(int id);
    Task<IEnumerable<Rol>> GetAllAsync();
    IEnumerable<Rol>  Find(Expression<Func<Rol, bool>> expression);
    void Add(Rol entity);
    void AddRange(IEnumerable<Rol> entities);
    void Remove(Rol entity);
    void RemoveRange(IEnumerable<Rol> entities);
    void Update(Rol entity);


}
