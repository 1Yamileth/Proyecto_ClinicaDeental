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


        public async Task<bool> ActualizarAsync(Cliente cliente)
        {
            return await clienteRepositorio.ActualizarAsync(cliente);
        }

        public async Task<bool> EliminarAsync(string codigoCliente)
        {
            return await clienteRepositorio.EliminarAsync(codigoCliente);
        }

        public async Task<IEnumerable<Cliente>> GetListaAsync()
        {
            return await clienteRepositorio.GetListaAsync();
        }

        public async Task<Cliente> GetPorCodigoAsync(string codigoCliente)
        {
            return await clienteRepositorio.GetPorCodigoAsync(codigoCliente);
        }

        public async Task<bool> NuevoAsync(Cliente cliente)
        {
            return await clienteRepositorio.NuevoAsync(cliente);
        }
    }
}
