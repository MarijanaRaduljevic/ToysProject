﻿using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.Interfaces;

namespace ToysApplication.Commands
{
    public interface IDeleteProductCommand : ICommand<int>
    {
    }
}
