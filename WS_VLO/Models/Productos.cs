using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_VLO.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public double Cantidad { get; set; }
        public string Fecha { get; set; }
        public double CantidadMinima { get; set; }
        public string UnidadMedida { get; set; }
        public bool Estado { get; set; }


        //Relación con categoria de Producto
        public int IdCategoria { get; set; }
    }
}