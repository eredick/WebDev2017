using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Models
{
    public class Customer
    {
        [ExplicitKey]
        public string CustomerID { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "La longitud mínima debe ser de 5 caracteres")]
        [Display(Name = "Compañía")]
        public string CompanyName { get; set; }
        [Display(Name = "Persona de Contacto")]
        public string ContactName { get; set; }
        [Display(Name = "Ciudad")]
        public string City { get; set; }
        [Display(Name = "País")]
        public string Country { get; set; }
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
    }
}
