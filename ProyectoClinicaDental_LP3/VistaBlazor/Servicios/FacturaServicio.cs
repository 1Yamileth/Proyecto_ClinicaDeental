using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Servicios
{
    public class FacturaServicio : IFacturaServicio
    {
        private readonly Config _config;
        private IFacturaRepositorio facturaRepositorio;

        public FacturaServicio(Config config)
        {
            _config = config;
            facturaRepositorio = new FacturaRepositorio(config.CadenaConexion);
        }

        public async Task<int> Nueva(Factura factura)
        {
            return await facturaRepositorio.Nueva(factura);
        }
    }
}
