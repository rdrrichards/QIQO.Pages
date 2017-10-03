using QIQO.Pages.Data.Entities;

namespace QIQO.Pages.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product> { }
    public interface IProductTypeRepository : IReadOnlyRepository<ProductType> { }
}
