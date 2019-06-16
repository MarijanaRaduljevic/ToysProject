using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysEfDataAccess;
using System.Linq;
using ToysApplication.Exceptions;

namespace ToysEfCommands
{
    public class EfGetOneProductCommand : IGetOneProductCommand
    {
        private readonly ToysContext _context;

        public EfGetOneProductCommand(ToysContext context)
        {
            _context = context;
        }

        public GetProductDto Execute(int request)
        {

        var product = _context.Products.Find(request);

            if (product == null)
            {
                throw new EntityNotFoundException("Product");
            }

            return new GetProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price
                
            };

            }
        
    }
}
