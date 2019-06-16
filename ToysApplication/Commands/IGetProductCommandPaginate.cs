using System;
using System.Collections.Generic;
using System.Text;
using ToysApplication.DTO;
using ToysApplication.Interfaces;
using ToysApplication.Response;
using ToysApplication.Searches;

namespace ToysApplication.Commands
{
    public interface IGetProductCommandPaginate : ICommand<ProductSearches, PagedResponse<GetProductDto>>
    {
    }
}
