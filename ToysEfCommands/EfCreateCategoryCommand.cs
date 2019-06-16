using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysDomain;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {

        private readonly ToysContext _context;

        public EfCreateCategoryCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(CreateCategoryDto request)
        {
            _context.Categories.Add(new Category
            {
                CreatedAt = DateTime.Now,
                CategoryName = request.CategoryName
            });


            _context.SaveChanges();
        }
    }
 }

