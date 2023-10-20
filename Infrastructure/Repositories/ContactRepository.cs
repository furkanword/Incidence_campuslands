using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ContactRepository : IContact
{
    private readonly IncidenceContext _context;
    public ContactRepository(IncidenceContext context)=>_context = context;

    public void Add(Contact entity)=>_context.Set<Contact>().Add(entity);

    public void AddRange(IEnumerable<Contact> entities)=>_context.Set<Contact>().AddRange(entities);

    public IEnumerable<Contact> Find(Expression<Func<Contact, bool>> expression)=>_context.Set<Contact>().Where(expression);

    public async Task<IEnumerable<Contact>> GetAllAsync()=>await _context.Set<Contact>().ToListAsync();

    public async Task<Contact> GetByIdAsync(int id)=>(await _context.Set<Contact>().FindAsync(id))!;

    public void Remove(Contact entity)=>_context.Set<Contact>().Remove(entity);

    public void RemoveRange(IEnumerable<Contact> entities)=>_context.Set<Contact>().RemoveRange(entities);

    public void Update(Contact entity)=>_context.Set<Contact>().Update(entity);
}