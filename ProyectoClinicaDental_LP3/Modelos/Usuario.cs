using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Usuario
    {
        //PROPIEDADES

        [Required(ErrorMessage = "El código es requerido")]
        public string CodigoUsuario { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        [Required(ErrorMessage = "El rol es requerido")]
        public string Rol { get; set; }
        public byte[] Foto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EstaActivo { get; set; }


        //CONSTRUCTORES
        public Usuario()
        {
        }

        public Usuario(string codigoUsuario, string nombre, string contrasena, string correo, string rol, byte[] foto, DateTime fechaCreacion, bool estaActivo)
        {
            CodigoUsuario = codigoUsuario;
            Nombre = nombre;
            Contrasena = contrasena;
            Correo = correo;
            Rol = rol;
            Foto = foto;
            FechaCreacion = fechaCreacion;
            EstaActivo = estaActivo;
        }
    }
}
