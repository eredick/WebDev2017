using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Models.ViewModels
{
    public class CreateUserVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Constraseña")]
        public string Password { get; set; }
        [Display(Name = "Roles")]
        public string Roles { get; set; }
    }
}
