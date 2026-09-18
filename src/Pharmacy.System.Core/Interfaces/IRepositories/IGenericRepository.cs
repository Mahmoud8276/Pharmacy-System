using Pharmacy.System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pharmacy.System.Core.Interfaces.IRepositories
{
    public interface IGenericRepository<TModel, TKey> where TModel : BaseModel<TKey>
    {
        public Task<TModel?> GetByIdAsync(TKey id);
        public Task<IReadOnlyList<TModel>> FindAsync(Expression<Func<TModel, bool>> condition);
        public Task<IReadOnlyList<TModel>> GetAllAsync();
        public Task AddAsync(TModel model);
        public Task AddRangeAsync(IEnumerable<TModel> models);
        public void UpdateAsync(TModel model);
        public void DeleteAsync(TModel model);
        public void DeleteRangeAsync(IEnumerable<TModel> models);
        public Task<IReadOnlyList<TModel>> GetAllWithSpecAsync(ISpecification<TModel, TKey> spec);
        public Task<int> GetCountWithSpecAsync(ISpecification<TModel, TKey> spec);
        public Task<TModel?> GetWithSpecAsync(ISpecification<TModel, TKey> spec);
    }
}
