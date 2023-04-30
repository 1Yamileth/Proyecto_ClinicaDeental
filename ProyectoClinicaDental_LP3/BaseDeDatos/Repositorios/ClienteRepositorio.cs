using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        private string CadenaConexion;

        public ClienteRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(ClienteM cliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"UPDATE cliente SET IdentidadCliente = @IdentidadCliente, Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion, FechaNacimiento = @FechaNacimiento
                                WHERE IdentidadCliente = @IdentidadCliente;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, cliente));
            }
            catch (Exception)
            {
            }
            return resultado;
        }


        public async Task<IEnumerable<ClienteM>> GetListaAsync()
        {
            IEnumerable<ClienteM> lista = new List<ClienteM>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "SELECT * FROM cliente;";
                lista = await _conexion.QueryAsync<ClienteM>(sql);
            }
            catch (Exception)
            {
            }
            return lista;
        }

        public async Task<ClienteM> GetPorCodigoAsync(string IdentidadCliente)
        {
            ClienteM cliente = new ClienteM();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "SELECT * FROM cliente WHERE IdentidadCliente = @IdentidadCliente;";
                cliente = await _conexion.QueryFirstAsync<ClienteM>(sql, new { IdentidadCliente });
            }
            catch (Exception)
            {
            }
            return cliente;
        }

        public async Task<bool> NuevoAsync(ClienteM cliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"INSERT INTO cliente (IdentidadCliente,Nombre,Telefono,Correo,Direccion,FechaNacimiento)
                                 VALUES (@IdentidadCliente,@Nombre,@Telefono,@Correo,@Direccion,@FechaNacimiento);";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, cliente));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<bool> EliminarAsync(string IdentidadCliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "DELETE FROM cliente WHERE IdentidadCliente = @IdentidadCliente;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { IdentidadCliente }));
            }
            catch (Exception)
            {
            }
            return resultado;
        }
    }
}
