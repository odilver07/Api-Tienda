using Data;
using Entitys;
using System.ComponentModel.DataAnnotations;

namespace Bussiness
{
    public class ClienteBns
    {
        dCliente clienteData;

        public ClienteBns(string sConnection)
        {
            clienteData = new dCliente(sConnection);
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await clienteData.GetAllClientes();
        }

        public async Task<IEnumerable<Cliente>> GetByIdCliente([Required] int id)
        {
            return await clienteData.GetByIdCliente(id);
        }

        public async Task<bool> CreateCliente(Cliente cliente)
        {
            return await clienteData.CreateCliente(cliente);
        }

        public async Task<bool> UpdateCliente([Required] Cliente cliente)
        {
            return await clienteData.UpdateCliente(cliente);
        }

        public async Task<bool> DeleteCliente([Required] int id)
        {
            return await clienteData.DeleteCliente(id);
        }

        public async Task<IEnumerable<Cliente>> Login(LoginDto login)
        {
            return await clienteData.Login(login);
        }
    }
}
