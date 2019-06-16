using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.DTO;
using ToysApplication.Interfaces;

namespace ToysApplication.Commands
{
    public interface IGetOneUserCommand : ICommand<int, GetUserDto>
    {
    }
}
