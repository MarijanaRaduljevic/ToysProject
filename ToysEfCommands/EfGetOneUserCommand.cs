using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Exceptions;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfGetOneUserCommand : IGetOneUserCommand
    {
        private readonly ToysContext _context;

        public EfGetOneUserCommand(ToysContext context)
        {
            _context = context;
        }

        public GetUserDto Execute(int request)
        {
            var user = _context.Users.Find(request);

            if(user == null)
            {
                throw new EntityNotFoundException("User");
            }

            return new GetUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                RoleName = user.Role.RoleName
            };
        }
    }
}
