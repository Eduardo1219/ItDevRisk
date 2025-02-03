using Domain.OperationCategory.Entity;
using Domain.OperationCategory.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OperationCategory.Service
{
    public class OperationCategoryService : IOperationCategoryService
    {
        private readonly IOperationCategoryRepository _repository;

        public OperationCategoryService(IOperationCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddCategory(OperationCategoryEntity categoryEntity)
        {
            await _repository.AddAsync(categoryEntity);
        }

        public async Task UpdateCategory(OperationCategoryEntity categoryEntity)
        {
            await _repository.UpdateAsync(categoryEntity);
        }

        public async Task RemoveCategory(OperationCategoryEntity categoryEntity)
        {
            await _repository.RemoveAsync(categoryEntity);
        }

        public async Task<List<OperationCategoryEntity>> GetAllCategories()
        {
            return await _repository.GetAll();
        }

        public async Task<OperationCategoryEntity> GetCategoryByPriorityLevel(int priority)
        {
            return await _repository.GetOneAsync(o => o.PriorityLevel == priority);
        }
    }
}
