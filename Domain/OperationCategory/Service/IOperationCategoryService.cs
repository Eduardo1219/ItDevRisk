using Domain.OperationCategory.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OperationCategory.Service
{
    public interface IOperationCategoryService
    {
        Task AddCategory(OperationCategoryEntity categoryEntity);
        Task UpdateCategory(OperationCategoryEntity categoryEntity);
        Task<List<OperationCategoryEntity>> GetAllCategories();
        Task<OperationCategoryEntity> GetCategoryByPriorityLevel(int priority);
    }
}
