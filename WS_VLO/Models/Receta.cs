using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_VLO.Models
{
    public class Receta
    {
        [Key]
        public int IdReceta { get; set; }
        
        public double CantidadUtilizada { get; set; }

        //Relación con Productos
        public int IdProducto { get; set; }

        //Relación con Menu
        public int IdMenu { get; set; }
    }
}