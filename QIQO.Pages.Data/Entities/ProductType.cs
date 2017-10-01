using System;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Pages.Data.Entities
{
    public class ProductType
    {
        [Key]
        public Guid ProductTypeId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The max length of a product type code is 20 characters")]
        public string ProductTypeCode { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "The max length of a product type name is 150 characters")]
        public string ProductTypeName { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The max length of a product type description is 255 characters")]
        public string ProductTypeDesc { get; set; }

        public DateTime AddedDateTime { get; set; }

        [MaxLength(30)]
        public string AddedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        [MaxLength(30)]
        public string UpdatedUserId { get; set; }
    }
}
