using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly Config _config;
        private IClienteRepositorio clienteRepositorio;

        public ClienteServicio(Config config)
        {
            _config = config;
            clienteRepositorio = new ClienteRepositorio(config.CadenaConexion);
        }


        public async Task<bool> ActualizarAsync(ClienteM cliente)
        {
            return await clienteRepositorio.ActualizarAsync(cliente);
        }

        public async Task<bool> EliminarAsync(string IdentidadCliente)
        {
            return await clienteRepositorio.EliminarAsync(IdentidadCliente);
        }

        public async Task<IEnumerable<ClienteM>> GetListaClienteAsync()
        {
            return await clienteRepositorio.GetListaAsync();
        }

        public async Task<ClienteM> GetPorCodigoAsync(string IdentidadCliente)
        {
            return await clienteRepositorio.GetPorCodigoAsync(IdentidadCliente);
        }

        public async Task<bool> NuevoAsync(ClienteM cliente)
        {
            return await clienteRepositorio.NuevoAsync(cliente);
        }
    }
}
