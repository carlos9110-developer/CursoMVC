using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.ViewModels
{
    public class ArchivoViewModel
    {
        [Required]
        [Display(Name = "Archivo 1",Description ="aca va el archivo 1")]
        public HttpPostedFileBase Archivo1 { get; set; }

        [Required]
        [Display(Name = "Archivo 2", Description = "aca va el archivo 2")]
        public HttpPostedFileBase Archivo2 { get; set; }

        [Required]
        public string Cadena { get; set; }
    }
}