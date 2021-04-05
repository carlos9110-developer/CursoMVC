using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoMVC.Models.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100,ErrorMessage ="El {0} debe tener al menos {1} caracteres",MinimumLength =1)]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Clave", ErrorMessage ="Las Contraseñas no son iguales")]
        public string ConfirmacionClave { get; set; }

        [Required]
        public decimal Edad { get; set; }

    }

    public class EditUserViewModel
    {
        public decimal Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Clave", ErrorMessage = "Las Contraseñas no son iguales")]
        public string ConfirmacionClave { get; set; }

        [Required]
        public decimal Edad { get; set; }

    }
}