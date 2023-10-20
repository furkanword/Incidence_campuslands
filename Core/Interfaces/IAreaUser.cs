
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IAreaUser
{
    //Interface
    Task<AreaUser> GetByIdAsync(int id);
    Task<IEnumerable<AreaUser>> GetAllAsync();
    IEnumerable<AreaUser>  Find(Expression<Func<AreaUser, bool>> expression);
    void Add(AreaUser entity);
    void AddRange(IEnumerable<AreaUser> entities);
    void Remove(AreaUser entity);
    void RemoveRange(IEnumerable<AreaUser> entities);
    void Update(AreaUser entity);

}
