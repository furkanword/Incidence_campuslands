
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface ITypeIncidence
{
    Task<TypeIncidence> GetByIdAsync(int id);
    Task<IEnumerable<TypeIncidence>> GetAllAsync();
    IEnumerable<TypeIncidence>  Find(Expression<Func<TypeIncidence, bool>> expression);
    void Add(TypeIncidence entity);
    void AddRange(IEnumerable<TypeIncidence> entities);
    void Remove(TypeIncidence entity);
    void RemoveRange(IEnumerable<TypeIncidence> entities);
    void Update(TypeIncidence entity);


}
