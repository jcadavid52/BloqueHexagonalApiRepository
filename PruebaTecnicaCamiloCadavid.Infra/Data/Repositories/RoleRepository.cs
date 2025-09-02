using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCamiloCadavid.Domain.Models;
using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.Infra.Data.Repositories
{
    [Repository]
    public class RoleRepository(DataContext dataContext) : GenericRepository<Role>(dataContext), IRoleRepository
    {
        public async Task<List<Role>> GetAllAsync() => await Query().ToListAsync();
    }
}
