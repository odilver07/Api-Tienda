using Data;
using Entitys;
using System.ComponentModel.DataAnnotations;


namespace Bussiness
{
    public class ClienteArticuloBns
    {
        dClienteArticulo clienteData;

        public ClienteArticuloBns(string sConnection)
        {
            clienteData = new dClienteArticulo(sConnection);
        }

        public async Task<IEnumerable<ClienteArticulo>> GetAllArticuloTienda()
        {
            return await clienteData.GetAllArticuloTienda();
        }

        public async Task<bool> CreateClienteArticulo(ClienteArticulo clienteArticulo)
        {
            return await clienteData.CreateClienteArticulo(clienteArticulo);
        }

        public async Task<bool> UpdateClienteArticulo([Required] ArticuloTienda articuloTienda)
        {
            return await clienteData.UpdateClienteArticulo(articuloTienda);
        }

        public async Task<bool> DeleteClienteArticulo([Required] int id)
        {
            return await clienteData.DeleteClienteArticulo(id);
        }
    }
}
