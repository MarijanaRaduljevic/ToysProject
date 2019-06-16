using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Interfaces;
using ToysApplication.Searches;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfGetProductCommand : IGetProductCommand
    {
        private readonly ToysContext _context;
        public EfGetProductCommand(ToysContext context)
        {
            _context = context;
        }


        public IEnumerable<GetProductDto> Execute(ProductSearches request)
        {
            var product = _context.Products.Include(c => c.Category).AsQueryable();

             if (request.MinPrice.HasValue)
             {
                 product = product.Where(p => p.Price >= request.MinPrice);
             }

             if (request.MaxPrice.HasValue)
                 {
                product = product.Where(p => p.Price <= request.MaxPrice);
            }

            if (request.ProductName != null)
            {
                    product = product.Where(p => p.ProductName.ToLower() == request.ProductName.Trim().ToLower());
            }

            if (request.CategoryName != null)
            {
                product = product.Where(p => p.Category.CategoryName.ToLower() == request.CategoryName.Trim().ToLower());
            }


            return product.Select(x => new GetProductDto
            {
                Id = x.Id,
                ProductName = x.ProductName,
                Description = x.Description,
                Price = x.Price,
                Src = x.Image.Src,
                CategoryName = x.Category.CategoryName
            });
        }

        
       
    }
}
