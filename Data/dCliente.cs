using Dapper;
using Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public  class dCliente
    {
        string sConnection;

        public dCliente(string sConnection)
        {
            this.sConnection = sConnection;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            using (var connection = new SqlConnection(sConnection))
            {
                connection.Open();

                var query = string.Format($"EXEC GetAllClientes");

                var result = await connection.QueryAsync<Cliente>(query);

                return result;
            }
        }

        public async Task<IEnumerable<Cliente>> GetByIdCliente([Required] int id)
        {
            using (var connection = new SqlConnection(sConnection))
            {
                connection.Open();

                var query = string.Format($"EXEC GetByID {id}");

                var result = await connection.QueryAsync<Cliente>(query);

                return result;
            }
        }

        public async Task<bool> CreateCliente([Required] Cliente cliente)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC CreateCliente '{cliente.Nombre}', '{cliente.Apellidos}', '{cliente.Direccion}', '{cliente.pass}'");

                    await connection.QueryAsync(query);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCliente([Required] Cliente cliente)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC UpdateCliente {cliente.Id} ,'{cliente.Nombre}', '{cliente.Apellidos}', '{cliente.Direccion}'");

                    await connection.QueryAsync(query);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCliente([Required] int id)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC DeleteCliente {id}");

                    await connection.QueryAsync(query);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Cliente>> Login([Required] LoginDto login)
        {
            using (var connection = new SqlConnection(sConnection))
            {
                connection.Open();

                var query = string.Format($"EXEC LoginCliente '{login.user}' ,'{login.pass}'");

                var result = await connection.QueryAsync<Cliente>(query);

                return result;
            }
        }
    }
}

