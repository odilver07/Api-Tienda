using Data;
using Entitys;
using System.ComponentModel.DataAnnotations;

namespace Bussiness
{
    public class ArticuloBns
    {
        dArticulo articuloData;

        public ArticuloBns(string sConnection)
        {
            articuloData = new dArticulo(sConnection);
        }

        public async Task<IEnumerable<Articulo>> GetAllArticulos()
        {
            return await articuloData.GetAllArticulos();
        }

        public async Task<IEnumerable<Articulo>> GetByIdArticulos(int id)
        {
            return await articuloData.GetByIdArticulos(id);
        }

        public async Task<bool> CreateArticulo(Articulo articulo)
        {
            return await articuloData.CreateArticulo(articulo);
        }

        public async Task<bool> UpdateArticulo(Articulo articulo)
        {
            return await articuloData.UpdateArticulo(articulo);
        }

        public async Task<bool> DeleteArticulo([Required] int id)
        {
            return await articuloData.DeleteArticulo(id);
        }
    }
}
