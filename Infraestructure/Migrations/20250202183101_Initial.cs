using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PriorityLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Sector = table.Column<int>(type: "INTEGER", nullable: false),
                    InitialValue = table.Column<decimal>(type: "TEXT", nullable: true),
                    EndValue = table.Column<decimal>(type: "TEXT", nullable: true),
                    DaysBeforeReferenceDate = table.Column<int>(type: "INTEGER", nullable: true),
                    DaysAfterReferenceDate = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationCategory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationCategory",
                columns: new[] { "Id", "DaysAfterReferenceDate", "DaysBeforeReferenceDate", "EndValue", "InitialValue", "Name", "PriorityLevel", "Sector" },
                values: new object[,]
                {
                    { new Guid("3d05755d-2e9d-488a-b75b-220433912879"), null, null, null, 1000000m, "MEDIUMRISK", 3, 1 },
                    { new Guid("b617f8ac-689b-4e5c-8545-b6168510d1b5"), null, 30, null, null, "EXPIRED", 1, 3 },
                    { new Guid("e01dd826-1f78-4ccf-802b-6606c5a37e3e"), null, null, null, 1000000m, "HIGHRISK", 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationCategory");
        }
    }
}
