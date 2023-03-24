namespace MemberPlatformDAL.UoW
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        IQueryable<T> AllQuery();

        Task Insert(T obj);

        Task Delete(int id);

        Task Update(T obj);
    }
}
