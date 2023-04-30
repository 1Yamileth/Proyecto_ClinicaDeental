namespace Modelos
{
    public class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public string CodigoServicio { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        public DetalleFactura()
        {
        }

        public DetalleFactura(int idDetalleFactura, int idFactura, string codigoServicio, string descripcion, decimal precio, decimal total)
        {
            IdDetalleFactura = idDetalleFactura;
            IdFactura = idFactura;
            CodigoServicio = codigoServicio;
            Descripcion = descripcion;
            Precio = precio;
            Total = total;
        }
    }
}
