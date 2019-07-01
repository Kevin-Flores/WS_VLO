using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_VLO.Models
{
    public class MTurnos
    {
        public int IdTurno { get; set; }

        public string Nombre { get; set; }

        public string HoraInicial { get; set; }

        public string HoraFinal { get; set; }

        public string Fecha { get; set; }
    }
}