namespace School.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);  
        Task<bool> SaveAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<bool> UpdateItemAsync(T item);
    }
}
