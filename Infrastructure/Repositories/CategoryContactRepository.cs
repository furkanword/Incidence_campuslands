using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CategoryContactRepository : ICategoryContact
{
    private readonly IncidenceContext _context;
    public CategoryContactRepository(IncidenceContext context)=>_context = context;

    public void Add(CategoryContact entity)=>_context.Set<CategoryContact>().Add(entity);

    public void AddRange(IEnumerable<CategoryContact> entities)=>_context.Set<CategoryContact>().AddRange(entities);

    public IEnumerable<CategoryContact> Find(Expression<Func<CategoryContact, bool>> expression)=>_context.Set<CategoryContact>().Where(expression);

    public async Task<IEnumerable<CategoryContact>> GetAllAsync()=>await _context.Set<CategoryContact>().ToListAsync();

    public async Task<CategoryContact> GetByIdAsync(int id)=>(await _context.Set<CategoryContact>().FindAsync(id))!;

    public void Remove(CategoryContact entity)=>_context.Set<CategoryContact>().Remove(entity);

    public void RemoveRange(IEnumerable<CategoryContact> entities)=>_context.Set<CategoryContact>().RemoveRange(entities);

    public void Update(CategoryContact entity)=>_context.Set<CategoryContact>().Update(entity);
}