//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CursoMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HC_USUARIOS
    {
        public decimal ID { get; set; }
        public string CORREO { get; set; }
        public string CLAVE { get; set; }
        public Nullable<decimal> ID_ESTADO { get; set; }
        public Nullable<decimal> EDAD { get; set; }
    
        public virtual HC_ESTADOS_USUARIOS HC_ESTADOS_USUARIOS { get; set; }
    }
}