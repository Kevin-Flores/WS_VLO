﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_VLO.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        public int Cantidad { get; set; }

        public string Cliente { get; set; }

        public int Estado { get; set; }
        //Relaciones

        //Numero de mesa
        public int IdMesa { get; set; }

        //Empleado
        public int IdEmpleado { get; set; }
    }
}