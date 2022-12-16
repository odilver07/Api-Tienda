using Data;
using Entitys;

namespace Bussiness
{
    public class TiendaBns
    {
        dTienda tiendaData;

        public TiendaBns(string sConnection)
        {
            tiendaData = new dTienda(sConnection);
        }

        public async Task<IEnumerable<Tienda>> GetAllTiendas()
        {
            return await tiendaData.GetAllTiendas();
        }

        public async Task<IEnumerable<Tienda>> GetByIdTiendas(int id)
        {
            return await tiendaData.GetByIdTiendas(id);
        }

        public async Task<bool> CreateTienda(Tienda tienda)
        {
            return await tiendaData.CreateTienda(tienda);
        }

        public async Task<bool> UpdateTienda(Tienda tienda)
        {
            return await tiendaData.UpdateTienda(tienda);
        }

        public async Task<bool> DeleteTienda(int id)
        {
            return await tiendaData.DeleteTienda(id);
        }
    }
}
