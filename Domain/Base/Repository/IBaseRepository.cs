using Domain.Base.Entity;
using System.Linq.Expressions;

namespace Domain.Base.Repository
{
    public interface IBaseRepository<TB> where TB : BaseEntity
    {
        Task AddAsync(TB entity);

        Task RemoveAsync(TB entity);

        Task RemoveByIdAsync(Guid id);

        Task UpdateAsync(TB entity);

        Task<TB> GetByIdAsync(Guid id);
        Task<TB> GetOneAsync(Expression<Func<TB, bool>> search);
        Task<List<TB>> FindAsync(Expression<Func<TB, bool>> search);
        Task UpdateManyAsync(List<TB> entities);
        Task RemoveManyAsync(List<TB> entity);
        Task AddRangeAsync(List<TB> entity);
        Task<List<TB>> GetAll();
    }
}
