using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class UserRepository : IUser
{
    private readonly IncidenceContext _context;
    public UserRepository(IncidenceContext context)=>_context = context;

    public void Add(User entity)=>_context.Set<User>().Add(entity);

    public void AddRange(IEnumerable<User> entities)=>_context.Set<User>().AddRange(entities);

    public IEnumerable<User> Find(Expression<Func<User, bool>> expression)=>_context.Set<User>().Where(expression);

    public async Task<IEnumerable<User>> GetAllAsync()=>await _context.Set<User>().ToListAsync();

    public async Task<User> GetByIdAsync(int id)=>(await _context.Set<User>().FindAsync(id))!;

    public void Remove(User entity)=>_context.Set<User>().Remove(entity);

    public void RemoveRange(IEnumerable<User> entities)=>_context.Set<User>().RemoveRange(entities);

    public void Update(User entity)=>_context.Set<User>().Update(entity);
}