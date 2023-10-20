
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface ILevelIncidence
{
    Task<LevelIncidence> GetByIdAsync(int id);
    Task<IEnumerable<LevelIncidence>> GetAllAsync();
    IEnumerable<LevelIncidence>  Find(Expression<Func<LevelIncidence, bool>> expression);
    void Add(LevelIncidence entity);
    void AddRange(IEnumerable<LevelIncidence> entities);
    void Remove(LevelIncidence entity);
    void RemoveRange(IEnumerable<LevelIncidence> entities);
    void Update(LevelIncidence entity);


}
