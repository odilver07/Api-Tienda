using Data;
using Entitys;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Bussiness
{
    public class ArticuloTiendaBns
    {
        dArticuloTienda articuloData;

        public ArticuloTiendaBns(string sConnection)
        {
            articuloData = new dArticuloTienda(sConnection);
        }

        public async Task<IEnumerable<ArticuloTienda>> GetAllArticuloTienda()
        {
            return await articuloData.GetAllArticuloTienda();   
        }

        public async Task<bool> CreateArticuloTienda(ArticuloTienda articuloTienda)
        {
            return await articuloData.CreateArticuloTienda(articuloTienda);
        }

        public async Task<bool> UpdateArticuloTienda(ArticuloTienda articuloTienda)
        {
            return await articuloData.UpdateArticuloTienda(articuloTienda);   
        }

        public async Task<bool> DeleteClienteArticulo(int id)
        {
            return await articuloData.DeleteClienteArticulo(id);
        }
    }
}
