using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PeripheralRepository : IPeripheral
{
    private readonly IncidenceContext _context;
    public PeripheralRepository(IncidenceContext context)=>_context = context;

    public void Add(Peripheral entity)=>_context.Set<Peripheral>().Add(entity);

    public void AddRange(IEnumerable<Peripheral> entities)=>_context.Set<Peripheral>().AddRange(entities);

    public IEnumerable<Peripheral> Find(Expression<Func<Peripheral, bool>> expression)=>_context.Set<Peripheral>().Where(expression);

    public async Task<IEnumerable<Peripheral>> GetAllAsync()=>await _context.Set<Peripheral>().ToListAsync();

    public async Task<Peripheral> GetByIdAsync(int id)=>(await _context.Set<Peripheral>().FindAsync(id))!;

    public void Remove(Peripheral entity)=>_context.Set<Peripheral>().Remove(entity);

    public void RemoveRange(IEnumerable<Peripheral> entities)=>_context.Set<Peripheral>().RemoveRange(entities);

    public void Update(Peripheral entity)=>_context.Set<Peripheral>().Update(entity);        

}

