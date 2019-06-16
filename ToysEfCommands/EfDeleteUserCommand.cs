using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.Exceptions;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly ToysContext _context;

        public EfDeleteUserCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            if(user == null)
            {
                throw new EntityNotFoundException("User");
            }

            _context.Users.Remove(user);

            _context.SaveChanges();
        }
    }
}
