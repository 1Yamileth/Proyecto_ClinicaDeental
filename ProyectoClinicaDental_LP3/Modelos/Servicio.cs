using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Servicio
    {
        //PROPIEDADES

        [Required(ErrorMessage = "El código es obligatorio")]
        public string CodigoServicio { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }

        public DateTime Duracion { get; set; }

        [Required(ErrorMessage = "El codigo es obligatorio")]
        public string CodigoUsuario { get; set; }

        public decimal Precio { get; set; }

        public bool EstadoActivo { get; set; }

        public DateTime Disponibilidad { get; set; }

        public Servicio()
        {
        }

        public Servicio(string codigoServicio, string descripcion, DateTime duracion, string codigoUsuario, decimal precio, bool estadoActivo, DateTime disponibilidad)
        {
            CodigoServicio = codigoServicio;
            Descripcion = descripcion;
            Duracion = duracion;
            CodigoUsuario = codigoUsuario;
            Precio = precio;
            EstadoActivo = estadoActivo;
            Disponibilidad = disponibilidad;
        }
    }
}
