using BackEnd.Context;
using BackEnd.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BackEnd.Repositories.Interfaces;
using System.Data;

namespace BackEnd.Repositories
{
    public class FacturasRepository : IFacturasRepository
    {
        private readonly DevLabContext _context;

        public FacturasRepository(DevLabContext context)
        {
            _context = context;
        }

        public async Task<int> InsertFactura(int idCliente, int numeroFactura, int numeroArticulos, decimal subtotalFactura, decimal totalImpuestos, decimal totalFactura)
        {
            var facturaIdParameter = new SqlParameter("@FACTURAID", SqlDbType.Int) { Direction = ParameterDirection.Output };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC SpInsertFactura @IDCLIENTE, @NUMEROFACTURA, @NUMEROARTICULOS, @SUBTOTALFACTURA, @TOTALIMPUESTOS, @TOTALFACTURA, @FACTURAID OUTPUT",
                new SqlParameter("@IDCLIENTE", idCliente),
                new SqlParameter("@NUMEROFACTURA", numeroFactura),
                new SqlParameter("@NUMEROARTICULOS", numeroArticulos),
                new SqlParameter("@SUBTOTALFACTURA", subtotalFactura),
                new SqlParameter("@TOTALIMPUESTOS", totalImpuestos),
                new SqlParameter("@TOTALFACTURA", totalFactura),
                facturaIdParameter);

            int facturaId = (int)facturaIdParameter.Value;

            return facturaId;
        }

        public async Task InsertFacturaDetalle(int idFactura, int idProducto, int cantidadProducto, decimal precioUnitario, decimal subtotalProducto, string notas = null)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC SpInsertFacturaDetalle @IDFACTURA, @IDPRODUCTO, @CANTIDADPRODUCTO, @PRECIOUNITARIO, @SUBTOTALPRODUCTO, @NOTAS",
                new SqlParameter("@IDFACTURA", idFactura),
                new SqlParameter("@IDPRODUCTO", idProducto),
                new SqlParameter("@CANTIDADPRODUCTO", cantidadProducto),
                new SqlParameter("@PRECIOUNITARIO", precioUnitario),
                new SqlParameter("@SUBTOTALPRODUCTO", subtotalProducto),
                new SqlParameter("@NOTAS", (object)notas ?? DBNull.Value));
        }

        public async Task<List<TblFactura>> GetFacturas(int? idCliente = null, int? idFactura = null)
        {
            var idClienteParam = new SqlParameter("@IDCLIENTE", idCliente ?? (object)DBNull.Value);
            var idFacturaParam = new SqlParameter("@IDFACTURA", idFactura ?? (object)DBNull.Value);

            var facturas = await _context.TblFacturas
                .FromSqlRaw("EXEC SpGetFactura @IDCLIENTE, @IDFACTURA", idClienteParam, idFacturaParam)
                .ToListAsync();

            return facturas;
        }
    }
}
