using Microsoft.AspNetCore.Mvc;
using Queries.Categoria;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly iCategoriaQueries _categoriaQueries;

        public CategoriaController(iCategoriaQueries categoriaQueries)
        {
            _categoriaQueries = categoriaQueries ?? throw new ArgumentNullException(nameof(categoriaQueries));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _categoriaQueries.GetAll();
            return Ok(result);
        }

    }
}
