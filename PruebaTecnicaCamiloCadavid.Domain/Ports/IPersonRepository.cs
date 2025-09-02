using PruebaTecnicaCamiloCadavid.Domain.Models;

namespace PruebaTecnicaCamiloCadavid.Domain.Ports
{
    public interface IPersonRepository:IGenericRepository<Person>
    {
        Task<List<Person>> GetAllAsync();

        Task<Person?> GetByIdAsync(int id);
    }
}
