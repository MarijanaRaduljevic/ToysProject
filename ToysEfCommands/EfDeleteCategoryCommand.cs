using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.Exceptions;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly ToysContext _context;

        public EfDeleteCategoryCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var category = _context.Categories.Find(request);

            if (category == null)
            {
                throw new EntityNotFoundException("Category");
            }

            _context.Categories.Remove(category);

            _context.SaveChanges();
        }
    }
}
