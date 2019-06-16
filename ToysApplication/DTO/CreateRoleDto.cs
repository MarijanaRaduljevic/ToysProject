using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToysApplication.DTO
{
    public class CreateRoleDto
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
