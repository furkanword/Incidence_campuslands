
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IDetailIncidence
{
    Task<DetailIncidence> GetByIdAsync(int id);
    Task<IEnumerable<DetailIncidence>> GetAllAsync();
    IEnumerable<DetailIncidence>  Find(Expression<Func<DetailIncidence, bool>> expression);
    void Add(DetailIncidence entity);
    void AddRange(IEnumerable<DetailIncidence> entities);
    void Remove(DetailIncidence entity);
    void RemoveRange(IEnumerable<DetailIncidence> entities);
    void Update(DetailIncidence entity);


}
