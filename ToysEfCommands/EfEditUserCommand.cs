using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Exceptions;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfEditUserCommand : IEditUserCommand
    {
        private readonly ToysContext _context;

        public EfEditUserCommand(ToysContext context)
        {
            _context = context;
        }

        public void Execute(CreateUserDto request)
        {
            var user = _context.Users.Find(request.Id);

            if (user == null)
            {
                throw new EntityNotFoundException("User");
            }

            if (!_context.Roles.Any(r => r.Id == request.RoleId))
            {
                throw new EntityNotFoundException("Role");
            }

            user.ModifiedAt = DateTime.Now;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Username = request.Username;
            user.Password = request.Password;
            user.RoleId = request.RoleId;

            _context.SaveChanges();
        }
    }
}
