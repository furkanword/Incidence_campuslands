using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class RolRepository : IRol
{
    private readonly IncidenceContext _context;
    public RolRepository(IncidenceContext context)=>_context = context;

    public void Add(Rol entity)=>_context.Set<Rol>().Add(entity);

    public void AddRange(IEnumerable<Rol> entities)=>_context.Set<Rol>().AddRange(entities);

    public IEnumerable<Rol> Find(Expression<Func<Rol, bool>> expression)=>_context.Set<Rol>().Where(expression);

    public async Task<IEnumerable<Rol>> GetAllAsync()=>await _context.Set<Rol>().ToListAsync();

    public async Task<Rol> GetByIdAsync(int id)=>(await _context.Set<Rol>().FindAsync(id))!;

    public void Remove(Rol entity)=>_context.Set<Rol>().Remove(entity);

    public void RemoveRange(IEnumerable<Rol> entities)=>_context.Set<Rol>().RemoveRange(entities);

    public void Update(Rol entity)=>_context.Set<Rol>().Update(entity);
}