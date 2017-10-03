using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QIQO.Pages.Data.Entities;
using QIQO.Pages.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            ProductTypes = _productRepository.GetAllAsync().Result
                .Select(x => x.ProductType)
                .Distinct()
                .Select(i => new SelectListItem { Value = i.ProductTypeId.ToString(), Text = i.ProductTypeName })
                .ToList();
        }

        [BindProperty]
        public Product Product { get; set; }
        public List<SelectListItem> ProductTypes { get; set; }

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