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

        public async Task<bool> ActualizarAsync(Cliente cliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"UPDATE Cliente SET IdentidadCliente = @IdentidadCliente, Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion, FechaNacimiento = @FechaNacimiento, EstaActivo = @EstadoActivo
                                WHERE IdentidadCliente = @IdentidadCliente;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, cliente));
            }
            catch (Exception)
            {
            }
            return resultado;
        }


        public async Task<IEnumerable<Cliente>> GetListaAsync()
        {
            IEnumerable<Cliente> lista = new List<Cliente>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "SELECT * FROM Cliente;";
                lista = await _conexion.QueryAsync<Cliente>(sql);
            }
            catch (Exception)
            {
            }
            return lista;
        }

        public async Task<Cliente> GetPorCodigoAsync(string IdentidadCliente)
        {
            Cliente cliente = new Cliente();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "SELECT * FROM Cliente WHERE IdentidadCliente = @IdentidadCliente;";
                cliente = await _conexion.QueryFirstAsync<Cliente>(sql, new { IdentidadCliente });
            }
            catch (Exception)
            {
            }
            return cliente;
        }

        public async Task<bool> NuevoAsync(Cliente cliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"INSERT INTO cliente (IdentidadCliente,Nombre,Telefono,Correo,Direccion,FechaNacimiento,EstadoActivo)
                                 VALUES (@IdentidadCliente,@Nombre,@Telefono,@Correo,@Direccion,@FechaNacimiento,@EstadoActivo);";
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
                string sql = "DELETE FROM Cliente WHERE IdentidadCliente = @IdentidadCliente;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { IdentidadCliente }));
            }
            catch (Exception)
            {
            }
            return resultado;
        }
    }
}
