using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QIQO.Pages.Data.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage ="The max length of a product code is 20 characters")]
        [Display(Name = "Product Code")]
        // [Remote("ProductCodeExists", "", ErrorMessage = "The product code already exits")]
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

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public DateTime AddedDateTime { get; set; }

        [MaxLength(30)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string AddedUserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public DateTime UpdatedDateTime { get; set; }

        [MaxLength(30)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string UpdatedUserId { get; set; }

        [Display(Name = "Product Type")]
        public ProductType ProductType { get; set; }

        [Display(Name = "Product Type")]
        [Required]
        public Guid ProductTypeId { get; set; }
    }
}
