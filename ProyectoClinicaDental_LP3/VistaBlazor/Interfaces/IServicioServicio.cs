using Modelos;

namespace VistaBlazor.Interfaces
{
    public interface IServicioServicio
    {
        Task<bool> Nuevo(Servicio servicio);
        Task<bool> Actualizar(Servicio servicio);
        Task<bool> Eliminar(string codigoServicio);
        Task<IEnumerable<Servicio>> GetLista();
        Task<Servicio> GetPorCodigo(string codigoServicio);
    }
}
