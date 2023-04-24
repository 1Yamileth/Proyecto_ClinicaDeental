using Modelos;

namespace Datos.Interfaces
{
    public interface IServicioRepositorio
    {
        Task<bool> Nuevo(Servicio servicio);
        Task<bool> Actualizar(Servicio servicio);
        Task<bool> Eliminar(string codigoServicio);
        Task<IEnumerable<Servicio>> GetLista();
        Task<Servicio> GetPorCodigo(string codigoServicio);
    }
}
