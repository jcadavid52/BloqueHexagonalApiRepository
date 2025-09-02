using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.Infra.Data.Repositories
{
    public class GenericRepository<T>(DataContext dataContext) : IGenericRepository<T> where T : class
    {
        public IQueryable<T> Query() => dataContext.Set<T>();

        public async Task Add(T Entity) => await dataContext.Set<T>().AddAsync(Entity);

        public void Delete(T Entity) => dataContext.Set<T>().Remove(Entity);
    }
}
