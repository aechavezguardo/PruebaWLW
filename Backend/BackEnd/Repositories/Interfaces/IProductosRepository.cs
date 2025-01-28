using BackEnd.Models;

namespace BackEnd.Repositories.Interfaces
{
    public interface IProductosRepository
    {
        Task<List<CatProducto>> GetProductos();
    }
}
