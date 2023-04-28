using Modelos;

namespace Datos.Interfaces
{
    public interface IFacturaRepositorio
    {
        Task<int> Nueva(Factura factura);
    }
}
