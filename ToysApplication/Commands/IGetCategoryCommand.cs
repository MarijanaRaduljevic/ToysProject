﻿using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.DTO;
using ToysApplication.Interfaces;
using ToysApplication.Searches;

namespace ToysApplication.Commands
{
    public interface IGetCategoryCommand : ICommand<CategorySearches, IEnumerable<GetCategoryDto>>
    {
    }
}
