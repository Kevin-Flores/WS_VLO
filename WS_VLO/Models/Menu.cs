using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_VLO.Models
{
    public class Menu
    {
        [Key]
        public int IdMenu { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public string Descripcion { get; set; }

        //Relación con Tipo de Menu
        public int IdTipoMenu { get; set; }
    }
}