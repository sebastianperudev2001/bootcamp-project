using Microsoft.AspNetCore.Mvc;
using Queries.Producto;
using Repositorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly iProductoRepositorio _productoRepositorio;
        private readonly iProductoQueries _productoQueries;


        public ProductoController(iProductoRepositorio productoRepositorio, iProductoQueries productoQueries)
        {
            _productoRepositorio = productoRepositorio;
            _productoQueries = productoQueries;

        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _productoQueries.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }



        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _productoQueries.GetAll();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Modelo.Producto producto)
        {
            var result = await _productoRepositorio.Create(producto);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Modelo.Producto producto)
        {
            var result = await _productoRepositorio.Update(producto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _productoRepositorio.Delete(id);
            return Ok(result);
        }
    }
}
