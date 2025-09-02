using PruebaTecnicaCamiloCadavid.Domain.Models;
using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.Infra.Data.Repositories
{
    [Repository]
    public class RolePersonRepository(DataContext dataContext) : GenericRepository<RolePerson>(dataContext), IRolePersonRepository
    {
    }
}
