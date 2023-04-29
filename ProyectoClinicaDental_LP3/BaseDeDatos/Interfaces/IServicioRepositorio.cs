using Modelos;

namespace Datos.Interfaces
{
    public interface IServicioRepositorio
    {
        Task<bool> Nuevo(ServicioM servicio);
        Task<bool> Actualizar(ServicioM servicio);
        Task<bool> Eliminar(string codigoServicio);
        Task<IEnumerable<ServicioM>> GetLista();
        Task<ServicioM> GetPorCodigo(string codigoServicio);
    }
}
