using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_VLO.Models
{
    public class TipoMenu
    {
        [Key]
        public int IdTipoMenu { get; set; }
        
        public string Nombre { get; set; }   
    }
}