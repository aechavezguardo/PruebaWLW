using BackEnd.Models;

namespace BackEnd.Repositories.Interfaces
{
    public interface IClientesRepository
    {
        Task<List<TblCliente>> GetClientes();
    }
}
