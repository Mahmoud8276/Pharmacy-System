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
        private readonly Lazy<IManufactorerRepository> _manufacturerRepository;
        private readonly Lazy<IProductFormRepository> _productFormRepository;
        private readonly Lazy<IBaseUnitRepository> _baseUnitRepository;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_context));
            _productCategoryRepository = new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(_context));
            _manufacturerRepository = new Lazy<IManufactorerRepository>(() => new ManufactorerRepository(_context));
            _productFormRepository = new Lazy<IProductFormRepository>(() => new ProductFormRepository(_context));
            _baseUnitRepository = new Lazy<IBaseUnitRepository>(() => new BaseUnitRepository(_context));
        }

        public IProductRepository ProductRepository => _productRepository.Value;
        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository.Value;
        public IManufactorerRepository ManufacturerRepository => _manufacturerRepository.Value;
        public IProductFormRepository ProductFormRepository => _productFormRepository.Value;
        public IBaseUnitRepository BaseUnitRepository => _baseUnitRepository.Value;



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
