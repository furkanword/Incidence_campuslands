
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IDocumentType
{
    Task<DocumentType> GetByIdAsync(int id);
    Task<IEnumerable<DocumentType>> GetAllAsync();
    IEnumerable<DocumentType>  Find(Expression<Func<DocumentType, bool>> expression);
    void Add(DocumentType entity);
    void AddRange(IEnumerable<DocumentType> entities);
    void Remove(DocumentType entity);
    void RemoveRange(IEnumerable<DocumentType> entities);
    void Update(DocumentType entity);


}
