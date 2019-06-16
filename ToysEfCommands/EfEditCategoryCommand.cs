using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Exceptions;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfEditCategoryCommand : IEditCategoryCommand
    {
        private readonly ToysContext _context;

        public EfEditCategoryCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(CreateCategoryDto request)
        {
            var category = _context.Categories.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFoundException("Category");
            }

            category.ModifiedAt = DateTime.Now;
            category.CategoryName = request.CategoryName;
            

            _context.SaveChanges();
        }
    }
}
