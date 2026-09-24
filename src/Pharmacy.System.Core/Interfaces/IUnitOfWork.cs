using Microsoft.EntityFrameworkCore.Storage;
using Pharmacy.System.Core.Interfaces.IRepositories;
using System;
using System.Threading.Tasks;

namespace Pharmacy.System.Core.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IProductRepository ProductRepository { get; }
        public IProductCategoryRepository ProductCategoryRepository { get; }

        public Task CompleteAsync();
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public Task CommitTransactionAsync();
        public Task RollbackTransactionAsync();
    }
}
