using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WS_VLO.Models
{
    //[DataContract(IsReference = true)]
    public class Roles
    {

        [Key]
        public int IdRol { get; set; }

        public string Tipo { get; set; }


        //Relaciones
        //public virtual List<Usuarios> Usuarios { get; set; }
    }
}