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
        [Description("Público")]
        PublicSector = 1,
        [Description("Privado")]
        PrivateSector = 2,
        [Description("Todos")]
        AnySector = 3
    }
}
