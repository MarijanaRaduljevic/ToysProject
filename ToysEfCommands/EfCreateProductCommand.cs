using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Exceptions;
using ToysDomain;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfCreateProductCommand : ICreateProductCommand
    {
        private readonly ToysContext _context;

        public EfCreateProductCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(CreateProductDto request)
        {
            if (!_context.Categories.Any(c => c.Id == request.CategoryId))
            {
                throw new EntityNotFoundException("Category");
                
            }
        
             if (!_context.Images.Any(i => i.Id == request.ImageId))
             {
             throw new EntityNotFoundException("Image");

              }

            _context.Products.Add(new Product
            {
                CreatedAt = DateTime.Now,
                ProductName = request.ProductName,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                ImageId = request.ImageId
            });

            _context.SaveChanges();
        }
    }
}
