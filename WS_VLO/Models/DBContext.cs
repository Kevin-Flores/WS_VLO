using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WS_VLO.Models
{
    public class DBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DBContext() : base("name=DBContext")
        {
            //Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

        }

        public System.Data.Entity.DbSet<WS_VLO.Models.Usuarios> Usuarios { get; set; }

        public System.Data.Entity.DbSet<WS_VLO.Models.Roles> Roles { get; set; }

        public System.Data.Entity.DbSet<WS_VLO.Controllers.Mesas> Mesas { get; set; }

        public System.Data.Entity.DbSet<WS_VLO.Models.Pedido> Pedidoes { get; set; }

        public System.Data.Entity.DbSet<WS_VLO.Models.Menu> Menus { get; set; }

        public System.Data.Entity.DbSet<WS_VLO.Models.TipoMenu> TipoMenus { get; set; }

        public System.Data.Entity.DbSet<WS_VLO.Models.DetallePedido> DetallePedidoes { get; set; }
    }
}
