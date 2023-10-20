using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class AreaUserRepository : IAreaUser
{
    private readonly IncidenceContext _context;
    public AreaUserRepository(IncidenceContext context)=>_context = context;

    public void Add(AreaUser entity)=>_context.Set<AreaUser>().Add(entity);

    public void AddRange(IEnumerable<AreaUser> entities)=>_context.Set<AreaUser>().AddRange(entities);

    public IEnumerable<AreaUser> Find(Expression<Func<AreaUser, bool>> expression)=>_context.Set<AreaUser>().Where(expression);

    public async Task<IEnumerable<AreaUser>> GetAllAsync()=>await _context.Set<AreaUser>().ToListAsync();

    public async Task<AreaUser> GetByIdAsync(int id)=>(await _context.Set<AreaUser>().FindAsync(id))!;

    public void Remove(AreaUser entity)=>_context.Set<AreaUser>().Remove(entity);

    public void RemoveRange(IEnumerable<AreaUser> entities)=>_context.Set<AreaUser>().RemoveRange(entities);

    public void Update(AreaUser entity)=>_context.Set<AreaUser>().Update(entity);
}