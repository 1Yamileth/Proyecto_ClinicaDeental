using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Servicios
{
    public class LoginServicio : ILoginServicio
    {
        private readonly Config _config;
        private ILoginRepositorio loginRepositorio;

        public LoginServicio(Config config)
        {
            _config = config;
            loginRepositorio = new LoginRepositorio(config.CadenaConexion);
        }
        public async Task<bool> ValidarUsuarioAsync(Login login)
        {
            return await loginRepositorio.ValidarUsuarioAsync(login);
        }
    }
}
