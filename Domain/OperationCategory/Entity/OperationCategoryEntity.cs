using Domain.Base.Entity;
using Domain.OperationCategory.Entity.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.OperationCategory.Entity
{
    [Table("OperationCategory")]
    public class OperationCategoryEntity : BaseEntity
    {
        public int PriorityLevel { get; set; }
        public string Name { get; set; }
        public SectorEnum Sector { get; set; }
        public decimal? InitialValue {  get; set; }
        public decimal? EndValue { get; set; }
        public int? DaysBeforeReferenceDate {  get; set; }
        public int? DaysAfterReferenceDate { get; set; }

        public bool ValidateOperation(DateTime referenceDate, DateTime nextPaymentDate, decimal value)
        {
            bool validDaysBefore = this.ValidateDaysAfter(referenceDate, nextPaymentDate);
            bool validDaysAfter = this.ValidateDaysBefore(referenceDate, nextPaymentDate);
            bool validInitalValue = this.ValidateInitialValue(value);
            bool validEndValue = this.ValidateInitialValue(value);

            return validDaysBefore && validDaysAfter && validInitalValue && validEndValue;
        }

        public bool ValidateInitialValue(decimal value)
        {
            bool isValid = true;

            if (this.InitialValue.HasValue)
            {
                isValid = value >= this.InitialValue.Value;
            }

            return isValid;
        }

        public bool ValidateEndValue(decimal value)
        {
            bool isValid = true;

            if (this.EndValue.HasValue)
            {
                isValid = value <= this.EndValue.Value;
            }

            return isValid;
        }

        public bool ValidateDaysAfter(DateTime referenceDate, DateTime nextPaymentDate)
        {
            bool isValid = true;

            if (this.DaysAfterReferenceDate.HasValue)
            {
                isValid = nextPaymentDate.AddDays(this.DaysAfterReferenceDate.Value) >= referenceDate;
            }

            return isValid;
        }

        public bool ValidateDaysBefore(DateTime referenceDate, DateTime nextPaymentDate)
        {
            bool isValid = true;


            if (this.DaysBeforeReferenceDate.HasValue)
            {
                isValid = nextPaymentDate.AddDays(this.DaysBeforeReferenceDate.Value) <= referenceDate;
            }

            return isValid;
        }
    }
}
