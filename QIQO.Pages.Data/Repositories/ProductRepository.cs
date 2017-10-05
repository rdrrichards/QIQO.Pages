using QIQO.Pages.Data.Interfaces;
using System;
using System.Collections.Generic;
using QIQO.Pages.Data.Entities;
using QIQO.Pages.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace QIQO.Pages.Data.Repositories
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext, IHttpContextAccessor httpContextAccessor) : base(productContext, httpContextAccessor)
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
            entity.UpdatedDateTime = DateTime.Now;
            entity.UpdatedUserId = User.Identity.Name;
            _productContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
