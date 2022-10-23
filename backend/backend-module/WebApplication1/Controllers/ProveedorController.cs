using Microsoft.AspNetCore.Mvc;
using Queries.Proveedor;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {

        private readonly iProveedorQueries _proovedorQueries;

        public ProveedorController(iProveedorQueries proveedorQueries)
        {
            _proovedorQueries = proveedorQueries ?? throw new ArgumentNullException(nameof(proveedorQueries));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _proovedorQueries.GetAll();
            return Ok(result);
        }

    }
}
