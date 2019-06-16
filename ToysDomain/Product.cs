using System;
using System.Collections.Generic;
using System.Text;

namespace ToysDomain
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }

  
    }
}
