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
        public async void Delete(Guid Id)
        {
            var product = await _productContext.Products.FindAsync(Id);
            _productContext.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIDAsync(Guid Id)
        {
            return await _productContext.Products.FindAsync(Id);
        }

        public async void Insert(Product entity)
        {
            await _productContext.Products.AddAsync(entity);
        }

        public void Save()
        {
            _productContext.SaveChangesAsync();
        }

        public void Update(Product entity)
        {
            _productContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
