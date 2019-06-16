using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.Exceptions;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfDeleteRoleCommand : IDeleteRoleCommand
    {
        private readonly ToysContext _context;

        public EfDeleteRoleCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var role = _context.Roles.Find(request);

            if (role == null)
            {
                throw new EntityNotFoundException("Role");
            }

            _context.Roles.Remove(role);

            _context.SaveChanges();


        }
    }
}
