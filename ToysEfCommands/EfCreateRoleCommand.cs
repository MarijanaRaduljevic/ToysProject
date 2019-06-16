using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysDomain;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfCreateRoleCommand : ICreateRoleCommand
    {
        private readonly ToysContext _context;

        public EfCreateRoleCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(CreateRoleDto request)
        {
            _context.Roles.Add(new Role
            {
                CreatedAt = DateTime.Now,
                RoleName = request.RoleName
            });

            _context.SaveChanges();
        }
    }
}
