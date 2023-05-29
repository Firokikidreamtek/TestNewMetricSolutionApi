using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NewMetricSolution.DB.Migrations
{
    public partial class Future : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingDepartment_ComplexObject_ComplexObjectId",
                table: "AccountingDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerServiceDepartment_ComplexObject_ComplexObjectId",
                table: "CustomerServiceDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionDepartment_ComplexObject_ComplexObjectId",
                table: "ProductionDepartment");

            migrationBuilder.DropTable(
                name: "ComplexObject");

            migrationBuilder.DropIndex(
                name: "IX_ProductionDepartment_ComplexObjectId",
                table: "ProductionDepartment");

            migrationBuilder.DropIndex(
                name: "IX_CustomerServiceDepartment_ComplexObjectId",
                table: "CustomerServiceDepartment");

            migrationBuilder.DropIndex(
                name: "IX_AccountingDepartment_ComplexObjectId",
                table: "AccountingDepartment");

            migrationBuilder.DropColumn(
                name: "ComplexObjectId",
                table: "ProductionDepartment");

            migrationBuilder.DropColumn(
                name: "ComplexObjectId",
                table: "CustomerServiceDepartment");

            migrationBuilder.DropColumn(
                name: "ComplexObjectId",
                table: "AccountingDepartment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComplexObjectId",
                table: "ProductionDepartment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComplexObjectId",
                table: "CustomerServiceDepartment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComplexObjectId",
                table: "AccountingDepartment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ComplexObject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexObject", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ComplexObject",
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountingDepartment",
                keyColumn: "Id",
                keyValue: 1,
                column: "ComplexObjectId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CustomerServiceDepartment",
                keyColumn: "Id",
                keyValue: 1,
                column: "ComplexObjectId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductionDepartment",
                keyColumn: "Id",
                keyValue: 1,
                column: "ComplexObjectId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionDepartment_ComplexObjectId",
                table: "ProductionDepartment",
                column: "ComplexObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServiceDepartment_ComplexObjectId",
                table: "CustomerServiceDepartment",
                column: "ComplexObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountingDepartment_ComplexObjectId",
                table: "AccountingDepartment",
                column: "ComplexObjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingDepartment_ComplexObject_ComplexObjectId",
                table: "AccountingDepartment",
                column: "ComplexObjectId",
                principalTable: "ComplexObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerServiceDepartment_ComplexObject_ComplexObjectId",
                table: "CustomerServiceDepartment",
                column: "ComplexObjectId",
                principalTable: "ComplexObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionDepartment_ComplexObject_ComplexObjectId",
                table: "ProductionDepartment",
                column: "ComplexObjectId",
                principalTable: "ComplexObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
