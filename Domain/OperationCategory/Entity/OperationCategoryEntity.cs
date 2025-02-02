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
    }
}
