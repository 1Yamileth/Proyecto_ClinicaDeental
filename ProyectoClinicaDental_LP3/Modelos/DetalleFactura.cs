using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    internal class DetalleFactura
    {
        public int idDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public string CodigoServicio { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
    }
}
