using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class StateRepository : IState
{
    private readonly IncidenceContext _context;
    public StateRepository(IncidenceContext context)=>_context = context;

    public void Add(State entity)=>_context.Set<State>().Add(entity);

    public void AddRange(IEnumerable<State> entities)=>_context.Set<State>().AddRange(entities);

    public IEnumerable<State> Find(Expression<Func<State, bool>> expression)=>_context.Set<State>().Where(expression);

    public async Task<IEnumerable<State>> GetAllAsync()=>await _context.Set<State>().ToListAsync();

    public async Task<State> GetByIdAsync(int id)=>(await _context.Set<State>().FindAsync(id))!;

    public void Remove(State entity)=>_context.Set<State>().Remove(entity);

    public void RemoveRange(IEnumerable<State> entities)=>_context.Set<State>().RemoveRange(entities);

    public void Update(State entity)=>_context.Set<State>().Update(entity);
}