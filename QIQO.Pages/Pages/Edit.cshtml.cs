using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QIQO.Pages.Data.Interfaces;
using QIQO.Pages.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QIQO.Pages.Pages
{
    public class EditModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public EditModel(IProductRepository productRepository)
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

            Product.UpdatedDateTime = DateTime.Now;
            Product.UpdatedUserId = User.Identity.Name;
            _productRepository.Update(Product);

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