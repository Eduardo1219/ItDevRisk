using Domain.Base.Repository;
using Domain.OperationCategory.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OperationCategory.Repository
{
    public interface IOperationCategoryRepository : IBaseRepository<OperationCategoryEntity>
    {
    }
}
