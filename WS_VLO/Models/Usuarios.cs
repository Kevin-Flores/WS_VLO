using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WS_VLO.Models
{
    
    public class Usuarios
    {

        [Key]
        public int IdUser { get; set; }

        public string Nombre { get; set; }

        public string Username { get; set; }
        
        public string Password { get; set; }

        ////Relaciones
        ////Tabla Empleado para asginar un usuario y contraseña a c/u
        //public int IdEmpleado { get; set; }
        //public virtual Empleado Empleado { get; set; }

        //Tabla Roles
        
        public int IdRol { get; set; }
        //public virtual Roles Roles { get; set; }
    }
}