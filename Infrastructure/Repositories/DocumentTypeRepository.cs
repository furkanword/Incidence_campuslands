using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class DocumentTypeRepository : IDocumentType
{
    private readonly IncidenceContext _context;
    public DocumentTypeRepository(IncidenceContext context)=>_context = context;

    public void Add(DocumentType entity)=>_context.Set<DocumentType>().Add(entity);

    public void AddRange(IEnumerable<DocumentType> entities)=>_context.Set<DocumentType>().AddRange(entities);

    public IEnumerable<DocumentType> Find(Expression<Func<DocumentType, bool>> expression)=>_context.Set<DocumentType>().Where(expression);

    public async Task<IEnumerable<DocumentType>> GetAllAsync()=>await _context.Set<DocumentType>().ToListAsync();

    public async Task<DocumentType> GetByIdAsync(int id)=>(await _context.Set<DocumentType>().FindAsync(id))!;

    public void Remove(DocumentType entity)=>_context.Set<DocumentType>().Remove(entity);

    public void RemoveRange(IEnumerable<DocumentType> entities)=>_context.Set<DocumentType>().RemoveRange(entities);

    public void Update(DocumentType entity)=>_context.Set<DocumentType>().Update(entity);
}