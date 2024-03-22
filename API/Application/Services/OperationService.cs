using API.Application.Contracts.Interfaces;
using API.Domain.Interfaces;
using API.Domain.Repositories;

namespace API.Application.Services
{
    public class OperationService<T> : IOperations<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public OperationService(IRepository<T> repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetById(Guid id) 
        {
            return await _repository.GetById(id);
        }

        public async Task<T> Add(T entity)
        {
            return await _repository.Add(entity);
        }

        public async Task<T> Update(T entity)
        {
            return await _repository.Update(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }
    }
}
