namespace Modelos
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public string IdentidadCliente { get; set; }
        public string CodigoUsuario { get; set; }
        public decimal ISV { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
