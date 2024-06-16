using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resources.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineStatus = table.Column<int>(type: "int", nullable: false),
                    LeaseStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "MachineId", "AcquisitionDate", "LeaseStatus", "MachineStatus", "Model", "Note" },
                values: new object[,]
                {
                    { new Guid("56c7eef9-4144-4ad6-9df3-15fbf6644d04"), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Local), 1, 1, "Model 2", "<no notes>" },
                    { new Guid("83365d55-cc81-4dfe-94e4-0433a74de3a0"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), 0, 0, "Model 1", "Maintanence 2024-08-01" },
                    { new Guid("9b0afc2a-b468-410b-81cd-2aef6bd6ac5f"), new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Local), 2, 0, "Model 3", "Upgraded to BBX7 battery" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
