using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QIQO.Pages.Data.Entities;
using QIQO.Pages.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace QIQO.Pages.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public DeleteModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task OnGetAsync(Guid id)
        {
            Product = await _productRepository.GetByIDAsync(id);
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _productRepository.DeleteAsync(Product.ProductId);

            try
            {
                await _productRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Product {Product.ProductName} : {Product.ProductName} not found!");
            }

            return RedirectToPage("/Index");
        }
    }
}