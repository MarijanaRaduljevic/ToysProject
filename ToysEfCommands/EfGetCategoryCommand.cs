using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Searches;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfGetCategoryCommand : IGetCategoryCommand
    {

        private readonly ToysContext _context;

        public EfGetCategoryCommand(ToysContext context)
        {
            _context = context;
        }

        public IEnumerable<GetCategoryDto> Execute(CategorySearches request)
        {
            var category = _context.Categories.AsQueryable();

            if (request.CategoryName != null)
            {
                category = category.Where(c => c.CategoryName.ToLower() == request.CategoryName.Trim().ToLower());
            }

            return category.Select(c => new GetCategoryDto
            {
                Id = c.Id,
                CategoryName = c.CategoryName
            });
        }
    }
}
