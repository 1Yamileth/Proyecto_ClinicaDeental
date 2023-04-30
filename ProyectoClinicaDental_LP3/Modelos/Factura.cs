using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Factura
    {
        [Required(ErrorMessage = "El código es requerido")]
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        [Required(ErrorMessage = "La identidad del cliente es requerida")]
        public string IdentidadCliente { get; set; }
        [Required(ErrorMessage = "El código de usuario es requerido")]
        public string CodigoUsuario { get; set; }
        public decimal ISV { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }

        public decimal Total { get; set; }

        public Factura()
        {
        }

        public Factura(int idFactura, DateTime fechaFactura, string identidadCliente, string codigoUsuario, decimal iSV, decimal descuento, decimal subtotal, decimal total)
        {
            IdFactura = idFactura;
            FechaFactura = fechaFactura;
            IdentidadCliente = identidadCliente;
            CodigoUsuario = codigoUsuario;
            ISV = iSV;
            Descuento = descuento;
            Subtotal = subtotal;
            Total = total;
        }
    }
}
