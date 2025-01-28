using BackEnd.Models;

namespace BackEnd.Repositories.Interfaces
{
    public interface IFacturasRepository
    {
        Task<int> InsertFactura(int idCliente, int numeroFactura, int numeroArticulos, decimal subtotalFactura, decimal totalImpuestos, decimal totalFactura);
        Task InsertFacturaDetalle(int idFactura, int idProducto, int cantidadProducto, decimal precioUnitario, decimal subtotalProducto, string notas = null);
        Task<List<TblFactura>> GetFacturas(int? idCliente = null, int? idFactura = null);
    }
}
