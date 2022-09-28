using ListaProductos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaProductos.Interfaces
{
    internal interface ICategoriaService
    {
        List<Categoria> GetCategorias();
    }
}
