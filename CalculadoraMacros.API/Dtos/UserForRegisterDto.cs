using System;
using System.ComponentModel.DataAnnotations;

namespace CalculadoraMacros.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
        public string Password { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Genre { get; set; }
        [Required]
        public decimal HeightValue { get; set; }
        [Required]
        public bool IsMetricSystem { get; set; }        
        public UserForRegisterDto()
        {
        }
    }
}