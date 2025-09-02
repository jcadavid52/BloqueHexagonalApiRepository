using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCamiloCadavid.Domain.Models;
using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.Infra.Data.Repositories
{
    [Repository]
    public class PersonRespository(DataContext dataContext) : GenericRepository<Person>(dataContext), IPersonRepository
    {
        public async Task<List<Person>> GetAllAsync()
        {
            return await Query()
                .Include(p => p.RolePerson)
                    .ThenInclude(rp => rp.Role)
                    .Include(p => p.Addresses)
                    .ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            return await Query()
                 .Include(p => p.RolePerson)
                    .ThenInclude(rp => rp.Role)
                    .Include(p => p.Addresses)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
