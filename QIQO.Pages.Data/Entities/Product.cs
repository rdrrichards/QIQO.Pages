using System;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Pages.Data.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage ="The max length of a product code is 20 characters")]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "The max length of a product name is 150 characters")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(1024, ErrorMessage = "The max length of a product short description is 1024 characters")]
        [Display(Name = "Product Short Description")]
        public string ProductDescShort { get; set; }

        [Display(Name = "Product Long Description")]
        public string ProductDescLong { get; set; }

        [MaxLength(255, ErrorMessage = "The max length of a product image path is 255 characters")]
        [Display(Name = "Product Image Path")]
        public string ProductImagePath { get; set; }

        public DateTime AddedDateTime { get; set; }

        [MaxLength(30)]
        public string AddedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        [MaxLength(30)]
        public string UpdatedUserId { get; set; }

        [Display(Name = "Product Type")]
        public ProductType ProductType { get; set; }

        [Display(Name = "Product Type")]
        public Guid ProductTypeId { get; set; }
    }
}
