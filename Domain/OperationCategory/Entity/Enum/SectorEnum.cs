using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OperationCategory.Entity.Enum
{
    public enum SectorEnum
    {
        [Description("Public")]
        PublicSector = 1,
        [Description("Private")]
        PrivateSector = 2,
        [Description("All")]
        AnySector = 3
    }
}
