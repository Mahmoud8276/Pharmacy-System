using Pharmacy.System.Core.Interfaces;
using Pharmacy.System.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using Pharmacy.System.Core.Interfaces.IRepositories;

namespace Pharmacy.System.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IProductCategoryRepository> _productCategoryRepository;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_context));
            _productCategoryRepository = new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(_context));
        }

        public IProductRepository ProductRepository => _productRepository.Value;
        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository.Value;



        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}
