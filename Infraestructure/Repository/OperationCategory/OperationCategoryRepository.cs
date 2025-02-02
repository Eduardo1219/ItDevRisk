using Domain.OperationCategory.Entity;
using Domain.OperationCategory.Repository;
using Infraestructure.Context;
using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.OperationCategory
{
    public class OperationCategoryRepository : BaseRepository<OperationCategoryEntity>, IOperationCategoryRepository
    {
        private readonly DevRiskContext _devRiskContext;

        public OperationCategoryRepository(DevRiskContext devRiskContext) : base(devRiskContext)
        {
            _devRiskContext = devRiskContext;
        }
    }
}
