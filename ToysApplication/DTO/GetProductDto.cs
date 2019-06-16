using System;
using System.Collections.Generic;
using System.Text;

namespace ToysApplication.DTO
{
    public class GetProductDto
    {
      
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Src { get; set; }

        public string CategoryName { get; set; }

        
    }
}
