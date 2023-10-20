
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IPlace
{
    Task<Place> GetByIdAsync(int id);
    Task<IEnumerable<Place>> GetAllAsync();
    IEnumerable<Place>  Find(Expression<Func<Place, bool>> expression);
    void Add(Place entity);
    void AddRange(IEnumerable<Place> entities);
    void Remove(Place entity);
    void RemoveRange(IEnumerable<Place> entities);
    void Update(Place entity);


}
