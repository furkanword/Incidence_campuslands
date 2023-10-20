
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IArea
{
    Task<Area> GetByIdAsync(int id);
    Task<IEnumerable<Area>> GetAllAsync();
    Task<(int totalRegistros, IEnumerable<Area> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    IEnumerable<Area>  Find(Expression<Func<Area, bool>> expression);
    void Add(Area entity);
    void AddRange(IEnumerable<Area> entities);
    void Remove(Area entity);
    void RemoveRange(IEnumerable<Area> entities);
    void Update(Area entity);


}
