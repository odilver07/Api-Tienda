using Bussiness;
using Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloTiendaController : ControllerBase
    {
        ArticuloTiendaBns articuloData;

        public ArticuloTiendaController(string sConnection)
        {
            articuloData = new ArticuloTiendaBns(sConnection);
        }

        [HttpGet]
        public List<ArticuloTienda> GetAll()
        {
            var result = articuloData.GetAllArticuloTienda();

            return result.Result.ToList();
        }

        [HttpPost]
        public bool CreateArticuloTienda(ArticuloTienda articuloTienda)
        {
            var result = articuloData.CreateArticuloTienda(articuloTienda);
            return result.Result;
        }

        [HttpPut]
        public bool UpdateArticuloTienda(ArticuloTienda articuloTienda)
        {
            var result = articuloData.UpdateArticuloTienda(articuloTienda);
            return result.Result;
        }

        [HttpDelete]
        public bool DeleteClienteArticulo(int id)
        {
            var result = articuloData.DeleteClienteArticulo(id);
            return result.Result;
        }
    }
}
