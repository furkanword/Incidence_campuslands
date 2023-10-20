using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class IncidenceRepository : IIncidence
{
    private readonly IncidenceContext _context;
    public IncidenceRepository(IncidenceContext context)=>_context = context;

    public void Add(Incidence entity)=>_context.Set<Incidence>().Add(entity);

    public void AddRange(IEnumerable<Incidence> entities)=>_context.Set<Incidence>().AddRange(entities);

    public IEnumerable<Incidence> Find(Expression<Func<Incidence, bool>> expression)=>_context.Set<Incidence>().Where(expression);

    public async Task<IEnumerable<Incidence>> GetAllAsync()=>await _context.Set<Incidence>().ToListAsync();

    public async Task<Incidence> GetByIdAsync(int id)=>(await _context.Set<Incidence>().FindAsync(id))!;

    public void Remove(Incidence entity)=>_context.Set<Incidence>().Remove(entity);

    public void RemoveRange(IEnumerable<Incidence> entities)=>_context.Set<Incidence>().RemoveRange(entities);

    public void Update(Incidence entity)=>_context.Set<Incidence>().Update(entity);
}