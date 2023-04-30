using Modelos;

namespace VistaBlazor.Interfaces
{
    public interface IClienteServicio
    {
        Task<ClienteM> GetPorCodigoAsync(string IdentidadCliente);
        Task<bool> NuevoAsync(ClienteM cliente);
        Task<bool> ActualizarAsync(ClienteM cliente);
        Task<bool> EliminarAsync(string IdentidadCliente);
        Task<IEnumerable<ClienteM>> GetListaClienteAsync();
    }
}

