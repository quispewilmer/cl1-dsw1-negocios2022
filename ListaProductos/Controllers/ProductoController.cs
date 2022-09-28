using ListaProductos.Models;
using ListaProductos.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace ListaProductos.Controllers
{
    public class ProductoController : Controller
    {
        ProductoService productoService = new ProductoService();
        CategoriaService categoriaService = new CategoriaService();

        // GET: Producto
        public ActionResult Index(Producto bean)
        {
            IEnumerable<Producto> productos = productoService.GetProductos();

            if (bean.IdCategoria != 0)
            {
                productos = from producto in productos where producto.IdCategoria == bean.IdCategoria select producto;
            }

            if (bean.NomProducto != null && !bean.NomProducto.IsEmpty())
            {
                productos = from producto in productos where producto.NomProducto.Contains(bean.NomProducto) select producto;
            }

            ViewBag.IdCategoria = new SelectList(categoriaService.GetCategorias(), "IdCategoria", "NombreCategoria");

            return View(productos);
        }
    }
}