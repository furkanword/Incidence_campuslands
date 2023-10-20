using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class LevelIncidenceRepository : ILevelIncidence
{
    private readonly IncidenceContext _context;
    public LevelIncidenceRepository(IncidenceContext context)=>_context = context;

    public void Add(LevelIncidence entity)=>_context.Set<LevelIncidence>().Add(entity);

    public void AddRange(IEnumerable<LevelIncidence> entities)=>_context.Set<LevelIncidence>().AddRange(entities);

    public IEnumerable<LevelIncidence> Find(Expression<Func<LevelIncidence, bool>> expression)=>_context.Set<LevelIncidence>().Where(expression);

    public async Task<IEnumerable<LevelIncidence>> GetAllAsync()=>await _context.Set<LevelIncidence>().ToListAsync();

    public async Task<LevelIncidence> GetByIdAsync(int id)=>(await _context.Set<LevelIncidence>().FindAsync(id))!;

    public void Remove(LevelIncidence entity)=>_context.Set<LevelIncidence>().Remove(entity);

    public void RemoveRange(IEnumerable<LevelIncidence> entities)=>_context.Set<LevelIncidence>().RemoveRange(entities);

    public void Update(LevelIncidence entity)=>_context.Set<LevelIncidence>().Update(entity);
}