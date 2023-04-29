using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Servicios
{
    public class ServicioServicio : IServicioServicio
    {
        private readonly Config _config;
        private IServicioRepositorio servicioRepositorio;

        public ServicioServicio(Config config)
        {
            _config = config;
            servicioRepositorio = new ServicioRepositorio(config.CadenaConexion);
        }
        public async Task<bool> Actualizar(ServicioM servicio)
        {
            return await servicioRepositorio.Actualizar(servicio);
        }

        public async Task<bool> Eliminar(string codigoServicio)
        {
            return await servicioRepositorio.Eliminar(codigoServicio);
        }

        public async Task<IEnumerable<ServicioM>> GetLista()
        {
            return await servicioRepositorio.GetLista();
        }

        public async Task<ServicioM> GetPorCodigo(string codigoServicio)
        {
            return await servicioRepositorio.GetPorCodigo(codigoServicio);
        }

        public async Task<bool> Nuevo(ServicioM servicio)
        {
            return await servicioRepositorio.Nuevo(servicio);
        }
    }
}
