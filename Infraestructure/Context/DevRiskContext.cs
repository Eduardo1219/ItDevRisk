using Domain.MockData.OperationCategoryMock;
using Domain.OperationCategory.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context
{
    public class DevRiskContext : DbContext
    {
        public DevRiskContext(DbContextOptions options) : base(options) { }

        public DbSet<OperationCategoryEntity> OperationCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OperationCategoryEntity>().HasData(OperationCategoryMock.GetMockCategoryEntities());
        }
    }
}
