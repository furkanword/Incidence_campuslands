using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;
public interface IIncidence
{
    Task<Incidence> GetByIdAsync(int id);
    Task<IEnumerable<Incidence>> GetAllAsync();
    IEnumerable<Incidence> Find(Expression<Func<Incidence, bool>> expression);
    void Add(Incidence entity);
    void AddRange(IEnumerable<Incidence> entities);
    void Remove(Incidence entity);
    void RemoveRange(IEnumerable<Incidence> entities);
    void Update(Incidence entity);
}