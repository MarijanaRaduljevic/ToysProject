using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Exceptions;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfEditProductCommand : IEditProductCommand
    {
        private readonly ToysContext _context;

        public EfEditProductCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(CreateProductDto request)
        {
            var product = _context.Products.Find(request.Id);

            if (product == null)
            {
                throw new EntityNotFoundException("Product");
            }

            if (!_context.Categories.Any(c => c.Id == request.CategoryId))
            {
                throw new EntityNotFoundException("Category");
            }


            if (!_context.Images.Any(i => i.Id == request.ImageId))
            {
                throw new EntityNotFoundException("Image");
            }

            product.ModifiedAt = DateTime.Now;
            product.ProductName = request.ProductName;
            product.Price = request.Price;
            product.Description = request.Description;
            product.ImageId = request.ImageId;
            product.CategoryId = request.CategoryId;

            _context.SaveChanges();
        }
    }
}
