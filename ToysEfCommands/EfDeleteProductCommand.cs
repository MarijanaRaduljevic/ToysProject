using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.Exceptions;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfDeleteProductCommand : IDeleteProductCommand
    {
        private readonly ToysContext _context;

        public EfDeleteProductCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var product = _context.Products.Find(request);

            if (product == null)
            {
                throw new EntityNotFoundException("Product");
            }

            _context.Products.Remove(product);

            _context.SaveChanges();
        }
    }
}
