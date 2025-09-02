using PruebaTecnicaCamiloCadavid.Domain.Models;

namespace PruebaTecnicaCamiloCadavid.Domain.Ports
{
    public interface IRoleRepository:IGenericRepository<Role>
    {
        Task<List<Role>> GetAllAsync();
    }
}
