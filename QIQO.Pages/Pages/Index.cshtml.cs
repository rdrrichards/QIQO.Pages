using Microsoft.AspNetCore.Mvc.RazorPages;
using QIQO.Pages.Data.Entities;
using QIQO.Pages.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Pages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task OnGetAsync()
        {
            Products = await _productRepository.GetAllAsync();
        }

        public IEnumerable<Product> Products { get; private set; } = new List<Product>();
    }
}
