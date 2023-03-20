namespace MemberPlatformDAL.UoW
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        IQueryable<T> AllQuery();

        void Insert(T obj);

        void Delete(int id);

        void Update(T obj);
    }
}
