using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.Exceptions;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfDeleteImageCommand : IDeleteImageCommand
    {
        private readonly ToysContext _context;

        public EfDeleteImageCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var image = _context.Images.Find(request);

            if(image == null)
            {
                throw new EntityNotFoundException("Image");
            }

            _context.Images.Remove(image);

            _context.SaveChanges();
        }
    }
}
