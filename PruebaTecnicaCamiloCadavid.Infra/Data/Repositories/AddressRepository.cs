using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCamiloCadavid.Domain.Models;
using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.Infra.Data.Repositories
{
    [Repository]
    public class AddressRepository(DataContext dataContext) : GenericRepository<Address>(dataContext), IAddressRepository
    {
        public async Task<List<Address>> GetAllAsync()
        {
            return await Query()
                .Include(a => a.Person)
                .ToListAsync();
        }
    }
}
