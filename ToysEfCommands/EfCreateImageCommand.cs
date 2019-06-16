using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysDomain;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfCreateImageCommand : ICreateImageCommand
    {
        private readonly ToysContext _context;

        public EfCreateImageCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(CreateImageDto request)
        {
            _context.Images.Add(new Image
            {
                
                CreatedAt = DateTime.Now,
                Src = request.Src,
                Alt = request.Alt,
                Title = request.Title
            });

            _context.SaveChanges();
        }
    }
    }

