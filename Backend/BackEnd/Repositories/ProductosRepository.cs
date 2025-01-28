using BackEnd.Context;
using BackEnd.Models;
using BackEnd.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly DevLabContext _context;

        public ProductosRepository(DevLabContext context)
        {
            _context = context;
        }

        public async Task<List<CatProducto>> GetProductos()
        {
            return await _context.CatProductos.ToListAsync();
        }
    }
}
