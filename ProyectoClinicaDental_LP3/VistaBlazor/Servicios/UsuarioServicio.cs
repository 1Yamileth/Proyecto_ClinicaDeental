using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly Config _config;
        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio(Config config)
        {
            _config = config;
            usuarioRepositorio = new UsuarioRepositorio(config.CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(Usuario usuario)
        {
            return await usuarioRepositorio.ActualizarAsync(usuario);
        }

        public async Task<bool> EliminarAsync(string codigoUsuario)
        {
            return await usuarioRepositorio.EliminarAsync(codigoUsuario);
        }

        public async Task<IEnumerable<Usuario>> GetListaAsync()
        {
            return await usuarioRepositorio.GetListaAsync();
        }

        public async Task<Usuario> GetPorCodigoAsync(string codigoUsuario)
        {
            return await usuarioRepositorio.GetPorCodigoAsync(codigoUsuario);
        }

        public async Task<bool> NuevoAsync(Usuario usuario)
        {
            return await usuarioRepositorio.NuevoAsync(usuario);
        }
    }
}
