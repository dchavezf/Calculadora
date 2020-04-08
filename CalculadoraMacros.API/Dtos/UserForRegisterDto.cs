using System.ComponentModel.DataAnnotations;

namespace CalculadoraMacros.API.Dtos {
    public class UserForRegisterDto {
        [Required]
        public string Name {
            get;
            set;
        }
        [Required]
        public string Email {
            get;
            set;
        }
        [Required]
        public string Code {
            get;
            set;
        }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Debes especificar un password entre 4 y 8 caracteres")]
        public string Password {
            get;
            set;
        }

    }
}