namespace Modelos
{
    public class DetalleFactura
    {
        public int idDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public string CodigoServicio { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
    }
}
