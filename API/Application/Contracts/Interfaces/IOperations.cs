namespace API.Application.Contracts.Interfaces
{
    public interface IOperations<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id); 
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(Guid id);
    }
}
