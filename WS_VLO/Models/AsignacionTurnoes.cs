//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WS_VLO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AsignacionTurnoes
    {
        public int IdAsignacion { get; set; }
        public int IdTurno { get; set; }
        public string Fecha { get; set; }
        public int IdUser { get; set; }
    
        public virtual Turnos Turnos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}