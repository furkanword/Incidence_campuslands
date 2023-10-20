using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ContactTypeRepository : IContactType
{
    private readonly IncidenceContext _context;
    public ContactTypeRepository(IncidenceContext context)=>_context = context;

    public void Add(ContactType entity)=>_context.Set<ContactType>().Add(entity);

    public void AddRange(IEnumerable<ContactType> entities)=>_context.Set<ContactType>().AddRange(entities);

    public IEnumerable<ContactType> Find(Expression<Func<ContactType, bool>> expression)=>_context.Set<ContactType>().Where(expression);

    public async Task<IEnumerable<ContactType>> GetAllAsync()=>await _context.Set<ContactType>().ToListAsync();

    public async Task<ContactType> GetByIdAsync(int id)=>(await _context.Set<ContactType>().FindAsync(id))!;

    public void Remove(ContactType entity)=>_context.Set<ContactType>().Remove(entity);

    public void RemoveRange(IEnumerable<ContactType> entities)=>_context.Set<ContactType>().RemoveRange(entities);

    public void Update(ContactType entity)=>_context.Set<ContactType>().Update(entity);
}