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
    public class dArticuloTienda
    {
        string sConnection;

        public dArticuloTienda(string sConnection)
        {
            this.sConnection = sConnection;
        }

        public async Task<IEnumerable<ArticuloTienda>> GetAllArticuloTienda()
        {
            using (var connection = new SqlConnection(sConnection))
            {
                connection.Open();

                var query = string.Format($"EXEC GetAllArticulos");

                var result = await connection.QueryAsync<ArticuloTienda>(query);

                return result;
            }
        }

        public async Task<bool> CreateArticuloTienda([Required] ArticuloTienda articuloTienda)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC CreateArticuloTienda {articuloTienda.Articulo}, {articuloTienda.Tienda}");

                    await connection.QueryAsync(query);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateArticuloTienda([Required] ArticuloTienda articuloTienda)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC UpdateArticuloTienda {articuloTienda.Id},{articuloTienda.Articulo}, {articuloTienda.Tienda}");

                    await connection.QueryAsync(query);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteClienteArticulo([Required] int id)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC DeleteArticuloTienda {id}");

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
