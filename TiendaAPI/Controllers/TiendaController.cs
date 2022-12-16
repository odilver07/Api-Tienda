using Bussiness;
using Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private TiendaBns tiendaData;
        public TiendaController(IConfiguration configuration)
        {
            tiendaData = new TiendaBns(configuration.GetConnectionString("Connection"));
        }

        [HttpGet]
        public List<Tienda> GetAllTienda()
        {
            var result = tiendaData.GetAllTiendas();

            return result.Result.ToList();
        }

        [HttpGet("GetById")]
        public Tienda GetByIdTienda([Required] int id)
        {
            var result = tiendaData.GetByIdTiendas(id);

            return result.Result.ToList().First();
        }

        [HttpPost]
        public bool CreateTienda([FromBody] Tienda tienda)
        {
            var result = tiendaData.CreateTienda(tienda);

            return result.Result;
        }

        [HttpPut]
        public bool UpdateTienda([FromBody] Tienda tienda)
        {
            var result = tiendaData.UpdateTienda(tienda);
            return result.Result;
        }

        [HttpDelete]
        public bool DeleteTienda([Required] int id)
        {
            var result = tiendaData.DeleteTienda(id);
            return result.Result;
        }
    }
}
