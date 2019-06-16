using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Exceptions;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfEditRoleCommand : IEditRoleCommand
    {
        private readonly ToysContext _context;

        public EfEditRoleCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(CreateRoleDto request)
        {
           var role = _context.Roles.Find(request.Id);

            if (role == null)
            {
                throw new EntityNotFoundException("Role");
            }

            role.ModifiedAt = DateTime.Now;
            role.RoleName = request.RoleName;


            _context.SaveChanges();

        }
    }
}
