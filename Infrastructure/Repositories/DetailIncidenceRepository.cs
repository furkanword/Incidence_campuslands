using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class DetailIncidenceRepository : IDetailIncidence
{
    private readonly IncidenceContext _context;
    public DetailIncidenceRepository(IncidenceContext context)=>_context = context;

    public void Add(DetailIncidence entity)=>_context.Set<DetailIncidence>().Add(entity);

    public void AddRange(IEnumerable<DetailIncidence> entities)=>_context.Set<DetailIncidence>().AddRange(entities);

    public IEnumerable<DetailIncidence> Find(Expression<Func<DetailIncidence, bool>> expression)=>_context.Set<DetailIncidence>().Where(expression);

    public async Task<IEnumerable<DetailIncidence>> GetAllAsync()=>await _context.Set<DetailIncidence>().ToListAsync();

    public async Task<DetailIncidence> GetByIdAsync(int id)=>(await _context.Set<DetailIncidence>().FindAsync(id))!;

    public void Remove(DetailIncidence entity)=>_context.Set<DetailIncidence>().Remove(entity);

    public void RemoveRange(IEnumerable<DetailIncidence> entities)=>_context.Set<DetailIncidence>().RemoveRange(entities);

    public void Update(DetailIncidence entity)=>_context.Set<DetailIncidence>().Update(entity);
}