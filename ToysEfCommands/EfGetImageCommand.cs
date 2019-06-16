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
    public class EfGetImageCommand : IGetImageCommand
    {
        private readonly ToysContext _context;

        public EfGetImageCommand(ToysContext context)
        {
            _context = context;
        }

        public IEnumerable<GetImageDto> Execute(ImageSearches request)
        {
            var image = _context.Images.AsQueryable();

            if (request.Alt != null)
            {
                image = image.Where(i => i.Alt.ToLower() == request.Alt.Trim().ToLower());
            }

            return image.Select(i => new GetImageDto
            {
                Id = i.Id,
                Src = i.Src,
                Alt = i.Alt,
                Title = i.Title
            });

        }
    }
}
