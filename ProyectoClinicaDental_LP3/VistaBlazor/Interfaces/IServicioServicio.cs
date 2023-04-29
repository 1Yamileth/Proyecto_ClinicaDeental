using Modelos;

namespace VistaBlazor.Interfaces
{
    public interface IServicioServicio
    {
        Task<bool> Nuevo(ServicioM servicio);
        Task<bool> Actualizar(ServicioM servicio);
        Task<bool> Eliminar(string codigoServicio);
        Task<IEnumerable<ServicioM>> GetLista();
        Task<ServicioM> GetPorCodigo(string codigoServicio);
    }
}
