using System;
using System.Collections.Generic;
using System.Text;

namespace ToysApplication.DTO
{
    public class GetRoleDto
    {
        public GetRoleDto()
            {
                Users = new List<GetUserDto>();
            }

        public int Id { get; set; }

        public string RoleName { get; set; }

        public List<GetUserDto> Users { get; set; }
    }
}
