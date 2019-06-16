using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.DTO;
using ToysApplication.Interfaces;

namespace ToysApplication.Commands
{
    public interface IGetOneCategoryCommand : ICommand<int, GetCategoryDto>
    {
    }
}
