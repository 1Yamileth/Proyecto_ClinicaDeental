using Datos.Interfaces;
using Datos.Repositorios;

namespace VistaBlazor.Servicios
{
    public class DetalleFacturaServicio : IDetalleFacturaRepositorio
    {
        private readonly Config _configuracion;
        private IDetalleFacturaRepositorio detalleFacturaRepositorio;

        public DetalleFacturaServicio(Config config)
        {
            _configuracion = config;
            detalleFacturaRepositorio = new DetalleFacturaRepositorio(config.CadenaConexion);
        }

        public async Task<bool> Nuevo(DetalleFactura detalleFactura)
        {
            return await detalleFacturaRepositorio.Nuevo(detalleFactura);
        }
    }
}
