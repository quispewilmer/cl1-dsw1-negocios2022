using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaProductos.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NomProducto { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public string CantxUnidad { get; set; }
        public decimal PrecioUnidad { get; set; }
        public short UnidadesEnExistencia { get; set; }
        public short UnidadesEnPedido { get; set; }
    }
}