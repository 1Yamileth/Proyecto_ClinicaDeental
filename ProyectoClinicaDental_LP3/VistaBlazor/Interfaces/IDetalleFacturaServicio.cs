using MySql.Data.MySqlClient;

namespace VistaBlazor.Interfaces
{
    public interface IDetalleFacturaServicio
    {
        private string CadenaConexion;

        public DetalleFacturaRepositorio(string _cadenaConexion)
        {
            CadenaConexon = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexon);
        }

        public async Task<bool> Nuevo(DetalleFactura detalleFactura)
        {
            bool inserto = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO detallefactura (IdFactura, CodigoProducto, Precio, Cantidad, Total) 
                               VALUES (@IdFactura, @CodigoProducto, @Precio, @Cantidad, @Total);";
                inserto = Convert.ToBoolean(await conexion.ExecuteAsync(sql, detalleFactura));
            }
            catch (Exception)
            {
            }
            return inserto;
        }
    }
}
