using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToysApplication.DTO
{
    public class CreateProductDto
    {
        public int Id { get; set; }
       
        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int ImageId { get; set; }
    }
}
