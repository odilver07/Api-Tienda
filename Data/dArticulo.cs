using Dapper;
using Entitys;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Data
{
    public class dArticulo
    {
        string sConnection;

        public dArticulo(string sConnection)
        {
            this.sConnection = sConnection;
        }

        public async Task<IEnumerable<Articulo>> GetAllArticulos()
        {
            using (var connection = new SqlConnection(sConnection))
            {
                connection.Open();

                var query = string.Format($"EXEC GetAllArticulos");

                var result = await connection.QueryAsync<Articulo>(query);

                return result;
            }
        }

        public async Task<IEnumerable<Articulo>> GetByIdArticulos([Required] int id)
        {
            using (var connection = new SqlConnection(sConnection))
            {
                connection.Open();

                var query = string.Format($"EXEC GetByIdArticulos {id}");

                var result = await connection.QueryAsync<Articulo>(query);

                return result;
            }
        }

        public async Task<bool> CreateArticulo([Required] Articulo articulo)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var extImagen = articulo.ExtesionImagen is null ? "null" : String.Format($"'{articulo.ExtesionImagen}'");
                    var nullWord = "null";

                    var query = string.Format($"EXEC CreateArticulo '{articulo.Descripcion}',{articulo.Precio},{(articulo.Imagen is null ? nullWord : articulo.Imagen.ToString)}, {extImagen}, {articulo.Stock}");

                    await connection.ExecuteAsync("EXEC CreateArticulo @Descripcion,@Precio,@Imagen,@ExtesionImagen,@Stock", 
                        new { Descripcion = articulo.Descripcion,Precio = articulo.Precio, Imagen = articulo.Imagen, ExtesionImagen = articulo.ExtesionImagen, Stock = articulo.Stock });

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateArticulo([Required] Articulo articulo)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var extImagen = articulo.ExtesionImagen is null ? "null" : String.Format($"'{articulo.ExtesionImagen}'");
                    var nullWord =  "null";

                    var query = string.Format($"EXEC UpdateArticulo {articulo.Codigo} ,'{articulo.Descripcion}',{articulo.Precio},{(articulo.Imagen is null ? nullWord : articulo.Imagen)}, {extImagen},{articulo.Stock}");

                    await connection.QueryAsync(query);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteArticulo([Required] int id)
        {
            try
            {
                using (var connection = new SqlConnection(sConnection))
                {
                    connection.Open();

                    var query = string.Format($"EXEC DeleteArticulo {id}");

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
