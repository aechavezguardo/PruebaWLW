using BackEnd.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosRepository _productosRepository;

        public ProductosController(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var response = await _productosRepository.GetProductos();

            if (response == null)
                return NotFound();

            return Ok(response);
        }
    }
}
