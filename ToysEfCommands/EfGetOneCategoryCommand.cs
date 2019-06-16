using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Exceptions;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfGetOneCategoryCommand : IGetOneCategoryCommand
    {
        private readonly ToysContext _context;

        public EfGetOneCategoryCommand(ToysContext context)
        {
            _context = context;
        }

        public GetCategoryDto Execute(int request)
        {
            var category = _context.Categories.Find(request);

            if (category == null)
            {
                throw new EntityNotFoundException("Category");
            }

            return new GetCategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName
               

            };
        }
    }
}
