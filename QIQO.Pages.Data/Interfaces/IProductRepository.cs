using QIQO.Pages.Data.Entities;

namespace QIQO.Pages.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product> {
        bool VerifyProductCode(string productCode);
    }
    public interface IProductTypeRepository : IReadOnlyRepository<ProductType> { }
}
