using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PromericaWebApp.Models
{
    public class TipoPrestamo
    {
        [Display(Name ="Tipo Prestamo")]
        public string tipoPrestamo { get; set; }

        [Display(Name = "Tasa")]
        public double tasa { get; set; }
    }
}