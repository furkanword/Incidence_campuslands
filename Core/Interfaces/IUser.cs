
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IUser
{
    Task<User> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    IEnumerable<User>  Find(Expression<Func<User, bool>> expression);
    void Add(User entity);
    void AddRange(IEnumerable<User> entities);
    void Remove(User entity);
    void RemoveRange(IEnumerable<User> entities);
    void Update(User entity);


}
