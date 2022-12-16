using Bussiness;
using Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteBns clienteData;
        public ClienteController(IConfiguration configuration)
        {
            clienteData = new ClienteBns(configuration.GetConnectionString("Connection"));
        }

        [HttpGet]
        public List<ClienteDto> GetAllClientes()
        {
            List<ClienteDto> clientesDto = new List<ClienteDto>();
            var result = clienteData.GetAllClientes();

            var clientes = result.Result.ToList();

            foreach (var cliente in clientes)
            {
                clientesDto.Add(new ClienteDto(cliente));
            }

            return clientesDto;
        }

        [HttpGet("GetById")]
        public Cliente GetByIdCliente(int id)
        {
            var result = clienteData.GetByIdCliente(id);

            return result.Result.ToList().First();
        }

        [HttpPost]
        public bool CreateCliente([FromBody] Cliente cliente)
        {
            var result = clienteData.CreateCliente(cliente);

            return result.Result;
        }

        [HttpPut]
        public bool UpdateCliente([FromBody] Cliente cliente)
        {
            var result = clienteData.UpdateCliente(cliente);
            return result.Result;
        }

        [HttpDelete]
        public bool DeleteCliente([Required] int id)
        {
            var result = clienteData.DeleteCliente(id);
            return result.Result;
        }

        [HttpPost("/login")]
        public string Login([FromBody] LoginDto login)
        {
            //string result = string.Empty;
            //byte[] encryted = System.Text.Encoding.Unicode.GetBytes(pass);
            //result = Convert.ToBase64String(encryted);
            //return result;

            var result = clienteData.Login(login);

            ClienteDto clienteDt = new ClienteDto(result.Result.ToList().First());

            return string.Format($"{clienteDt.Id}");
        }
    }
}
