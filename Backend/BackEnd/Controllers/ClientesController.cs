using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository _clientesRepository;

        public ClientesController(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var response = await _clientesRepository.GetClientes();

            if (response == null)
                return NotFound();

            return Ok(response);
        }
    }
}
