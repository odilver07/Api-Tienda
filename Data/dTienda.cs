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
    public class dTienda
    {
        string sConnection;

        public dTienda(string sConnection)
        {
            this.sConnection = sConnection;
        }

        public async Task<IEnumerable<Tienda>> GetAllTiendas()
        {
            using (var connection = new SqlConnection(sConnection))
            {
                connection.Open();

                var query = string.Format($"EXEC GetAllTiendas");

                var result = await connection.QueryAsync<Tienda>(query);

                return result;
            }
        }

        public async Task<IEnumerable<Tienda>> GetByIdTiendas(int id)
        {
            using (var connection = new SqlConnection(sConnection))
            {
                connection.Open();

                var query = string.Format($"EXEC GetByIdTienda {id}");

                var result = await connection.QueryAsync<Tienda>(query);

                return result;
            }
        }

        public async Task<bool> CreateTienda([Required] Tienda tienda)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC CreateTienda '{tienda.Sucursal}', '{tienda.Direccion}'");

                    await connection.QueryAsync(query);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateTienda([Required] Tienda tienda)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC UpdateTienda {tienda.Id} ,'{tienda.Sucursal}', '{tienda.Direccion}'");

                    await connection.QueryAsync(query);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteTienda([Required] int id)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC DeleteTienda {id}");

                    await connection.QueryAsync(query);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
