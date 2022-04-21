using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PromericaWebApp.Models
{
    public class Prestamo
    {
        [Display(Name= "Número de Prestamo")]
        public int numeroPrestamo { get; set; }

        [Display(Name = "Fecha de Apertura")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaApertura { get; set; }

        [Display(Name = "Número de Cliente")]
        public int numeroCliente { get; set; }

        [Display(Name = "Cédula")]
        public string cedula { get; set; }

        [Display(Name = "Agencia")]
        public string nombreAgencia { get; set; }

        [Display(Name = "Monto")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double monto { get; set; }

        [Display(Name = "Tasa")]
        public double tasa { get; set; }



        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double valor { get; set; }



    }
}