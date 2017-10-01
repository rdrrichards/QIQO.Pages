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
        public string ProductCode { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "The max length of a product name is 150 characters")]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(1024, ErrorMessage = "The max length of a product short description is 1024 characters")]
        public string ProductDescShort { get; set; }
        
        public string ProductDescLong { get; set; }

        [MaxLength(255, ErrorMessage = "The max length of a product image path is 255 characters")]
        public string ProductImagePath { get; set; }

        public DateTime AddedDateTime { get; set; }

        [MaxLength(30)]
        public string AddedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        [MaxLength(30)]
        public string UpdatedUserId { get; set; }
    }
}
