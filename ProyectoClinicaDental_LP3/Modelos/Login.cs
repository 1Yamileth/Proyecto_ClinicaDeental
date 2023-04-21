namespace Modelos
{
    public class Login
    {
        //PROPIEDADES
        public string CodigoUsuario { get; set; }
        public string Contrasena { get; set; }

        //CONSTRUCTORES
        public Login()
        {
        }

        public Login(string codigoUsuario, string contrasena)
        {
            CodigoUsuario = codigoUsuario;
            Contrasena = contrasena;
        }
    }
}
