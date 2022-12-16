using Bussiness;
using Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteArticuloController : ControllerBase
    {
        ClienteArticuloBns clienteData;

        public ClienteArticuloController(IConfiguration configuration)
        {
            clienteData = new ClienteArticuloBns(configuration.GetConnectionString("Connection"));
        }

        [HttpGet]
        public List<ClienteArticulo> GetAll()
        {
            var result = clienteData.GetAllArticuloTienda();
            return result.Result.ToList();
        }

        [HttpPost]
        public bool CreateClienteArticulo([FromBody] ClienteArticulo clienteArticulo)
        {
            var result = clienteData.CreateClienteArticulo(clienteArticulo);
            return result.Result;
        }

        [HttpPut]
        public bool UpdateClienteArticulo([FromBody] ArticuloTienda articuloTienda)
        {
            var result = clienteData.UpdateClienteArticulo(articuloTienda);
            return result.Result;
        }

        [HttpDelete]
        public bool DeleteClienteArticulo([Required] int id)
        {
            var result = clienteData.DeleteClienteArticulo(id);
            return result.Result;
        }
    }
}
