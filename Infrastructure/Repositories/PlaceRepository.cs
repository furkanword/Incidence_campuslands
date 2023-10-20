using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PlaceRepository : IPlace
{
    private readonly IncidenceContext _context;
    public PlaceRepository(IncidenceContext context)=>_context = context;

    public void Add(Place entity)=>_context.Set<Place>().Add(entity);

    public void AddRange(IEnumerable<Place> entities)=>_context.Set<Place>().AddRange(entities);

    public IEnumerable<Place> Find(Expression<Func<Place, bool>> expression)=>_context.Set<Place>().Where(expression);

    public async Task<IEnumerable<Place>> GetAllAsync()=>await _context.Set<Place>().ToListAsync();

    public async Task<Place> GetByIdAsync(int id)=>(await _context.Set<Place>().FindAsync(id))!;
    public void Remove(Place entity)=>_context.Set<Place>().Remove(entity);

    public void RemoveRange(IEnumerable<Place> entities)=>_context.Set<Place>().RemoveRange(entities);

    public void Update(Place entity)=>_context.Set<Place>().Update(entity);
}