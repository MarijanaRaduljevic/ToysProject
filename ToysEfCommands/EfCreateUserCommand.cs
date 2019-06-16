using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Exceptions;
using ToysApplication.Interfaces;
using ToysDomain;
using ToysEfDataAccess;

namespace ToysEfCommands
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly ToysContext _context;
        private readonly IEmail _email;

        public EfCreateUserCommand(ToysContext context, IEmail email)
        {
            _context = context;
            _email = email;
        }

        public void Execute(CreateUserDto request)
        {
            if (!_context.Roles.Any(r => r.Id == request.RoleId))
                {
                    throw new EntityNotFoundException("Role");
                }

            _context.Users.Add(new User
            {
                CreatedAt = DateTime.Now,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,
                RoleId = request.RoleId
             });

            _context.SaveChanges();


            _email.Subject = "Uspesna registracija";
            _email.Body = "Uspesno ste se registrovali na Toys.";
            _email.ToEmail = "netcoreict@gmail.com";
            _email.Send();
        }
    }
}
