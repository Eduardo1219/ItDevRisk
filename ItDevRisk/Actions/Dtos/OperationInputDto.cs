using Domain.OperationCategory.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItDevRisk.Actions.Dtos
{
    public class OperationInputDto
    {
        public OperationInputDto()
        {

        }

        public OperationInputDto(decimal negotiatedValue, SectorEnum sector, DateTime nextPaymentDate)
        {
            NegotiatedValue = negotiatedValue;
            Sector = sector;
            NextPaymentDate = nextPaymentDate;
        }

        public decimal NegotiatedValue { get; set; }
        public SectorEnum Sector {  get; set; }
        public DateTime NextPaymentDate {  get; set; }
    }
}
