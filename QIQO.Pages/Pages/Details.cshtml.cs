using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QIQO.Pages.Data.Entities;
using QIQO.Pages.Data.Interfaces;
using System;

namespace QIQO.Pages.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public DetailsModel(IProductRepository productRepository, IProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }

        public void OnGet(Guid id)
        {
            Product = _productRepository.GetByIDAsync(id).Result;
            Product.ProductType = _productTypeRepository.GetByIDAsync(Product.ProductTypeId).Result;
        }

        [BindProperty]
        public Product Product { get; private set; } = new Product();
    }
}