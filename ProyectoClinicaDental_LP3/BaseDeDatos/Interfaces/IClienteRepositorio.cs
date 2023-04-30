using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<ClienteM> GetPorCodigoAsync(string IdentidadCliente);
        Task<bool> NuevoAsync(ClienteM cliente);
        Task<bool> ActualizarAsync(ClienteM cliente);
        Task<bool> EliminarAsync(string IdentidadCliente);
        Task<IEnumerable<ClienteM>> GetListaAsync();
    }
}
