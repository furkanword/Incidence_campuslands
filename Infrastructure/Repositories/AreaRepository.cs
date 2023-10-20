using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class AreaRepository : IArea
{
    private readonly IncidenceContext _context;
    public AreaRepository(IncidenceContext context)=>_context = context;

    public void Add(Area entity)=>_context.Set<Area>().Add(entity);

    public void AddRange(IEnumerable<Area> entities)=>_context.Set<Area>().AddRange(entities);

    public IEnumerable<Area> Find(Expression<Func<Area, bool>> expression)=>_context.Set<Area>().Where(expression);

    public async Task<IEnumerable<Area>> GetAllAsync()=>await _context.Set<Area>().ToListAsync();
    public async Task<(int totalRegistros, IEnumerable<Area> registros)> GetAllAsync(int pageIndex, int pageSize){
        var totalRegistros = await _context.Set<Area>().CountAsync();
        var registros = await _context.Set<Area>()
            .Include(u => u.Places)
            .Skip((pageIndex - 1 ) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<(int totalRegistros, IEnumerable<Area> registros)> GetAllAsync(int pageIndex, int pageSize, string search){
        var query = _context.Areas as IQueryable<Area>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Name_Area.ToLower().Contains(search));
        }        
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(u => u.Places)
            .Skip((pageIndex - 1 ) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<Area> GetByIdAsync(int id){
         return _context.Areas.Include(a => a.Places).FirstOrDefault(a => a.Id_Area == id);
    }

    public void Remove(Area entity)=>_context.Set<Area>().Remove(entity);

    public void RemoveRange(IEnumerable<Area> entities)=>_context.Set<Area>().RemoveRange(entities);

    public void Update(Area entity)=>_context.Set<Area>().Update(entity);
}