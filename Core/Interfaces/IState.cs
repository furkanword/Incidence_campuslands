
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IState
{
    Task<State> GetByIdAsync(int id);
    Task<IEnumerable<State>> GetAllAsync();
    IEnumerable<State>  Find(Expression<Func<State, bool>> expression);
    void Add(State entity);
    void AddRange(IEnumerable<State> entities);
    void Remove(State entity);
    void RemoveRange(IEnumerable<State> entities);
    void Update(State entity);


}
