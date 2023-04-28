using Modelos;

namespace VistaBlazor.Interfaces
{
    public interface IFacturaServicio
    {
        Task<int> Nueva(Factura factura);
    }
}
