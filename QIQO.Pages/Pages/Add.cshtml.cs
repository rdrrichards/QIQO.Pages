using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QIQO.Pages.Data.Entities;
using QIQO.Pages.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QIQO.Pages.Pages
{
    public class AddModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public AddModel(IProductRepository productRepository, IProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;

            ProductTypes = _productTypeRepository.GetAllAsync().Result
                .Select(i => new SelectListItem { Value = i.ProductTypeId.ToString(), Text = i.ProductTypeName })
                .ToList();
        }

        public void OnGetAsync()
        {
            Product = new Product
            {
                ProductId = Guid.NewGuid(),
                AddedDateTime = DateTime.Now,
                AddedUserId = User.Identity.Name,
                UpdatedDateTime = DateTime.Now,
                UpdatedUserId = User.Identity.Name
            };
        }

        [BindProperty]
        public Product Product { get; set; }
        public List<SelectListItem> ProductTypes { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _productRepository.InsertAsync(Product);

            try
            {
                await _productRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToPage("/Index");
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult ProductCodeExists(string productCode)
        {
            // var code = _productRepository.GetAllAsync().Result.ToList().FirstOrDefault(p => p.ProductCode == productCode);
            // return new JsonResult(_productRepository.VerifyProductCode(productCode) ? "true" : "The code is already taken");
            if (!_productRepository.VerifyProductCode(productCode))
            {
                return new JsonResult($"Product code {productCode} is already in use.");
            }

            return new JsonResult(true);

        }
    }
}