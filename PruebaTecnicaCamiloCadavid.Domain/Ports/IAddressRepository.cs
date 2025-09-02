using PruebaTecnicaCamiloCadavid.Domain.Models;

namespace PruebaTecnicaCamiloCadavid.Domain.Ports
{
    public interface IAddressRepository:IGenericRepository<Address>
    {
        Task<List<Address>> GetAllAsync();
    }
}
