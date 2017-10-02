using QIQO.Pages.Data.Interfaces;
using System;
using System.Collections.Generic;
using QIQO.Pages.Data.Entities;
using QIQO.Pages.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace QIQO.Pages.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public async Task DeleteAsync(Guid Id)
        {
            var product = await _productContext.Products.FindAsync(Id);
            _productContext.Products.Remove(product);
        }
        
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productContext.Products.Include("ProductType").ToListAsync();
        }

        public async Task<Product> GetByIDAsync(Guid Id)
        {
            return await _productContext.Products.FindAsync(Id);
        }

        public async Task InsertAsync(Product entity)
        {
            await _productContext.Products.AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await _productContext.SaveChangesAsync();
        }

        public void Update(Product entity)
        {
            _productContext.Entry(entity).State = EntityState.Modified;
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    _productContext.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
