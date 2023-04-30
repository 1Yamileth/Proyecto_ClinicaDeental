using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ClienteM
    {
        [Required(ErrorMessage = "La identidad del cliente es requerida")]
        public string IdentidadCliente { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El telefono es requerido")]
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public ClienteM()
        {
        }

        public ClienteM(string identidadCliente, string nombre, string telefono, string correo, string direccion, DateTime fechaNacimiento, bool estadoActivo)
        {
            IdentidadCliente = identidadCliente;
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
        }
    }

}
