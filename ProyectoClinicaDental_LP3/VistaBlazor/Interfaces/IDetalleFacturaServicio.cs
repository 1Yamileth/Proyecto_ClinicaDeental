using Modelos;

namespace VistaBlazor.Interfaces
{
    public interface IDetalleFacturaServicio
    {
        Task<bool> Nuevo(DetalleFactura detalleFactura);
    }
}
