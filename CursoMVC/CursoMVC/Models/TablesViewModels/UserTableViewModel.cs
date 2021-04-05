using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.TablesViewModels
{
    public class UserTableViewModel
    {
        public decimal ID { get; set; }
        public string CORREO { get; set; }

        public decimal? EDAD { get; set; }
    }
}