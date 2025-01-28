using BackEnd.Models;
using BackEnd.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturasRepository _facturasRepository;

        public FacturasController(IFacturasRepository facturasRepository)
        {
            _facturasRepository = facturasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetFacturas(int? idcliente, int? idfactura)
        {
            try
            {
                if (idcliente == null && idfactura == null)
                    return BadRequest();

                var response = await _facturasRepository.GetFacturas(idcliente, idfactura);

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("InsertFactura")]
        public async Task<IActionResult> InsertFactura([FromBody] TblFactura factura)
        {
            try
            {
                var response = await _facturasRepository.InsertFactura(factura.IdCliente, factura.NumeroFactura, factura.NumeroTotalArticulos, factura.SubTotalFacturas, factura.TotalImpuestos, factura.TotalFactura);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("InsertFacturaDetalle")]
        public async Task<IActionResult> InsertFacturaDetalle([FromBody] TblDetalleFactura facturaDetalle)
        {
            try
            {
                await _facturasRepository.InsertFacturaDetalle(facturaDetalle.IdFactura, facturaDetalle.IdProducto, facturaDetalle.CantidadDeProducto, facturaDetalle.PrecioUnitarioProducto, facturaDetalle.SubtotalProducto, facturaDetalle.Notas);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
