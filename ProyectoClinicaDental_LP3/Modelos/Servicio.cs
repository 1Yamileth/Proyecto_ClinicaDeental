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
        public string CodigoUsuario { get; set; }
        public decimal Precio { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime Disponibilidad { get; set; }

    }
}
