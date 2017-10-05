using QIQO.Pages.Data.Interfaces;
using System;
using System.Collections.Generic;
using QIQO.Pages.Data.Entities;
using QIQO.Pages.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace QIQO.Pages.Data.Repositories
{
    public class ProductTypeRepository: RepositoryBase, IProductTypeRepository
    {
        private readonly ProductContext _productContext;

        public ProductTypeRepository(ProductContext productContext) : base(productContext, null)
        {
            _productContext = productContext;
        }

        public async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            return await _productContext.ProductTypes.ToListAsync();
        }

        public async Task<ProductType> GetByIDAsync(Guid Id)
        {
            return await _productContext.ProductTypes.FindAsync(Id);
        }
    }
}
