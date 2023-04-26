using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class ServicioRepositorio : IServicioRepositorio
    {
        private string CadenaConexion;

        public ServicioRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }


        public async Task<bool> Actualizar(Servicio servicio)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"UPDATE servicio SET Descripcion = @Descripcion, Duracion = @Duracion, CodigoUsuario = @CodigoUsuario, Precio = @Precio, EstadoActivo = @EstadoActivo, Disponibilidad = @Disponibilidad, 
                                 WHERE CodigoServicio = @CodigoServicio;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, servicio));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<bool> Eliminar(string codigoServicio)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "DELETE FROM servicio WHERE CodigoServicio = @CodigoServicio;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { codigoServicio }));
            }
            catch (Exception)
            {
            }
            return resultado;

        }

        public async Task<IEnumerable<Servicio>> GetLista()
        {
            IEnumerable<Servicio> lista = new List<Servicio>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "SELECT * FROM servicio;";
                lista = await _conexion.QueryAsync<Servicio>(sql);
            }
            catch (Exception)
            {
            }
            return lista;

        }

        public async Task<Servicio> GetPorCodigo(string codigoServicio)
        {
            Servicio prod = new Servicio();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "SELECT * FROM servicio WHERE CodigoServicio = @CodigoServicio;";
                prod = await _conexion.QueryFirstAsync<Servicio>(sql, new { codigoServicio });
            }
            catch (Exception)
            {
            }
            return prod;
        }

        public async Task<bool> Nuevo(Servicio servicio)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"INSERT INTO servicio (CodigoServicio, Descripcion, Duracion, CodigoUsuario, Precio, EstadoActivo, Disponibilidad)
                                 VALUES (@CodigoServicio, @Descripcion, @Duracion, @CodigoUsuario, @Precio, @EstadoActivo, @Disponibilidad);";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, servicio));
            }
            catch (Exception)
            {
            }
            return resultado;
        }
    }
}
