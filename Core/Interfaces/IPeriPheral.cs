
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IPeripheral
{
    Task<Peripheral> GetByIdAsync(int id);
    Task<IEnumerable<Peripheral>> GetAllAsync();
    IEnumerable<Peripheral>  Find(Expression<Func<Peripheral, bool>> expression);
    void Add(Peripheral entity);
    void AddRange(IEnumerable<Peripheral> entities);
    void Remove(Peripheral entity);
    void RemoveRange(IEnumerable<Peripheral> entities);
    void Update(Peripheral entity);


}
