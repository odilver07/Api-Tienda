using Bussiness;
using Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private ArticuloBns articuloData;
        public ArticuloController(IConfiguration configuration)
        {
            articuloData = new ArticuloBns(configuration.GetConnectionString("Connection"));
        }

        [HttpGet]
        public List<Articulo> GetAllClientes()
        {
            var result = articuloData.GetAllArticulos();

            return result.Result.ToList();
        }

        [HttpGet("GetById")]
        public Articulo GetByIdArticulo([Required] int id)
        {
            var result = articuloData.GetByIdArticulos(id);
            return result.Result.ToList().First();
        }

        [HttpPost]
        public bool CreateCliente([FromBody]Articulo articulo)
        {
            var result = articuloData.CreateArticulo(articulo);

            return result.Result;
        }

        [HttpPut]
        public bool UpdateCliente([FromBody] Articulo articulo)
        {
            var result = articuloData.UpdateArticulo(articulo);
            return result.Result;
        }

        [HttpDelete]
        public bool DeleteCliente([Required] int id)
        {
            var result = articuloData.DeleteArticulo(id);
            return result.Result;
        }
    }
}
