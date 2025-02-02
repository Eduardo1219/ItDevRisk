using Domain.OperationCategory.Entity;
using Domain.OperationCategory.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MockData.OperationCategoryMock
{
    public static class OperationCategoryMock
    {
        public static List<OperationCategoryEntity> GetMockCategoryEntities()
        {
            return new List<OperationCategoryEntity>
            {
                new OperationCategoryEntity
                {
                    Id = Guid.Parse("b617f8ac-689b-4e5c-8545-b6168510d1b5"),
                    Name = "EXPIRED",
                    DaysBeforeReferenceDate = 30,
                    PriorityLevel = 1,
                    Sector = SectorEnum.AnySector,
                },
                new OperationCategoryEntity
                {
                    Id = Guid.Parse("e01dd826-1f78-4ccf-802b-6606c5a37e3e"),
                    Name = "HIGHRISK",
                    PriorityLevel = 2,
                    Sector = SectorEnum.PrivateSector,
                    InitialValue = 1000000
                },
                new OperationCategoryEntity
                {
                    Id = Guid.Parse("3d05755d-2e9d-488a-b75b-220433912879"),
                    Name = "MEDIUMRISK",
                    PriorityLevel = 3,
                    Sector = SectorEnum.PublicSector,
                    InitialValue = 1000000
                },
            };
        }
    }
}
