using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_VLO.Models
{
    public class AsignacionTurno
    {
        [Key]
        public int IdAsignacion { get; set; }

        public int IdTurno { get; set; }
        
        public string Fecha { get; set; }

        public int IdUser { get; set; }
    }
}