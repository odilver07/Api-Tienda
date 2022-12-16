using Dapper;
using Entitys;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;


namespace Data
{
    public class dClienteArticulo
    {
        string sConnection;

        public dClienteArticulo(string sConnection)
        {
            this.sConnection = sConnection;
        }

        public async Task<IEnumerable<ClienteArticulo>> GetAllArticuloTienda()
        {
            using (var connection = new SqlConnection(sConnection))
            {
                connection.Open();

                var query = string.Format($"EXEC GetAllClienteArticulo");

                var result = await connection.QueryAsync<ClienteArticulo>(query);

                return result;
            }
        }

        public async Task<bool> CreateClienteArticulo([Required] ClienteArticulo clienteArticulo)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC CreateClienteArticulo {clienteArticulo.Cliente}, {clienteArticulo.Articulo}");

                    await connection.QueryAsync(query);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateClienteArticulo([Required] ArticuloTienda articuloTienda)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC UpdateClienteArticulo {articuloTienda.Id},{articuloTienda.Articulo}, {articuloTienda.Tienda}");

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

                    var query = string.Format($"EXEC DeleteClienteArticulo {id}");

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
