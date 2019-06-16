using System;
using System.Collections.Generic;
using System.Text;

namespace ToysApplication.Searches
{
    public class ProductSearches
    {
        public int? Id { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }
    }
}
