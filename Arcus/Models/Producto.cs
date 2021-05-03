using System;
using System.Collections.Generic;
using System.Text;

namespace Arcus.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }

    }
}
