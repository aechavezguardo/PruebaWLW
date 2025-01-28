using BackEnd.Context;
using BackEnd.Models;
using BackEnd.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly DevLabContext _context;

        public ClientesRepository(DevLabContext context)
        {
            _context = context;
        }

        public async Task<List<TblCliente>> GetClientes()
        {
            return await _context.TblClientes.ToListAsync();
        }
    }
}
