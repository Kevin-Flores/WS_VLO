using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_VLO.Models
{
    public class ListaBebida
    {
        public List<Pedido> pedidos;
        public List<DetallePedido> detalle;
        public List<Menu> menus;
        public List<TipoMenu> tipomenu;
    }
}