using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_VLO.Controllers
{
    public class Mesas
    {
        [Key]
        public int IdMesa { get; set; }
        
        public string NumMesa { get; set; }

        //[Required(ErrorMessage = "Este campo es requerido")]
        //[Range(0, int.MaxValue, ErrorMessage = "Debe ingresar un valor numérico.")]
        //[Display(Name ="Número de mesa")]
        //public int NumMesa { get; set; }
        
        public bool Estado { get; set; }
    }
}