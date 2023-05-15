using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : Base
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);

        Task<int> CountAsync(ISpecification<T> spec);
    }
}