using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToysApplication.DTO
{
    public class CreateUserDto
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]{2,10}$", ErrorMessage = "Ime nije u ispravnom formatu.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]{2,20}$", ErrorMessage = "Prezime nije u ispravnom formatu.")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
