namespace PruebaTecnicaCamiloCadavid.Domain.Ports
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query();

        Task Add(T Entity);

        void Delete(T Entity);
    }
}
