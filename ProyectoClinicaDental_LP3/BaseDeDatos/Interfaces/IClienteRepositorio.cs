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
        Task<Cliente> GetPorCodigoAsync(string IdentidadCliente);
        Task<bool> NuevoAsync(Cliente cliente);
        Task<bool> ActualizarAsync(Cliente cliente);
        Task<bool> EliminarAsync(string IdentidadCliente);
        Task<IEnumerable<Cliente>> GetListaAsync();
    }
}
