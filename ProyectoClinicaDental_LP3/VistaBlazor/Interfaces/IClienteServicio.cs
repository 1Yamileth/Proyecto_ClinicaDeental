using Modelos;

namespace VistaBlazor.Interfaces
{
    public interface IClienteServicio
    {
        Task<Cliente> GetPorCodigoAsync(string codigoCliente);
        Task<bool> NuevoAsync(Cliente cliente);
        Task<bool> ActualizarAsync(Cliente cliente);
        Task<bool> EliminarAsync(string codigoCliente);
        Task<IEnumerable<Cliente>> GetListaAsync();
    }
}

