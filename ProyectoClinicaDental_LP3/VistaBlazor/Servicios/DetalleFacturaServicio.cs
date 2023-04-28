using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Servicios
{
    public class DetalleFacturaServicio : IDetalleFacturaServicio
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
