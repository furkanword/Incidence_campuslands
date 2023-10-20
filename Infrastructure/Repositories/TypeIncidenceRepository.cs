using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class TypeIncidenceRepository : ITypeIncidence
{
    private readonly IncidenceContext _context;
    public TypeIncidenceRepository(IncidenceContext context)=>_context = context;

    public void Add(TypeIncidence entity)=>_context.Set<TypeIncidence>().Add(entity);

    public void AddRange(IEnumerable<TypeIncidence> entities)=>_context.Set<TypeIncidence>().AddRange(entities);

    public IEnumerable<TypeIncidence> Find(Expression<Func<TypeIncidence, bool>> expression)=>_context.Set<TypeIncidence>().Where(expression);

    public async Task<IEnumerable<TypeIncidence>> GetAllAsync()=>await _context.Set<TypeIncidence>().ToListAsync();

    public async Task<TypeIncidence> GetByIdAsync(int id)=>(await _context.Set<TypeIncidence>().FindAsync(id))!;

    public void Remove(TypeIncidence entity)=>_context.Set<TypeIncidence>().Remove(entity);

    public void RemoveRange(IEnumerable<TypeIncidence> entities)=>_context.Set<TypeIncidence>().RemoveRange(entities);

    public void Update(TypeIncidence entity)=>_context.Set<TypeIncidence>().Update(entity);
}