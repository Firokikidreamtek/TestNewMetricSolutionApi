using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NewMetricSolution.DB.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "AccountingDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComplexObjectId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountingDepartment_ComplexObject_ComplexObjectId",
                        column: x => x.ComplexObjectId,
                        principalTable: "ComplexObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerServiceDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComplexObjectId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServiceDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerServiceDepartment_ComplexObject_ComplexObjectId",
                        column: x => x.ComplexObjectId,
                        principalTable: "ComplexObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComplexObjectId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionDepartment_ComplexObject_ComplexObjectId",
                        column: x => x.ComplexObjectId,
                        principalTable: "ComplexObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogisticsDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerServiceDepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogisticsDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogisticsDepartment_CustomerServiceDepartment_CustomerServi~",
                        column: x => x.CustomerServiceDepartmentId,
                        principalTable: "CustomerServiceDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerServiceDepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesDepartment_CustomerServiceDepartment_CustomerServiceDe~",
                        column: x => x.CustomerServiceDepartmentId,
                        principalTable: "CustomerServiceDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngineeringDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductionDepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineeringDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EngineeringDepartment_ProductionDepartment_ProductionDepart~",
                        column: x => x.ProductionDepartmentId,
                        principalTable: "ProductionDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasingDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductionDepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasingDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasingDepartment_ProductionDepartment_ProductionDepartm~",
                        column: x => x.ProductionDepartmentId,
                        principalTable: "ProductionDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QualityControlDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductionDepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityControlDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityControlDepartment_ProductionDepartment_ProductionDep~",
                        column: x => x.ProductionDepartmentId,
                        principalTable: "ProductionDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LogisticsDepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryDepartment_LogisticsDepartment_LogisticsDepartmentId",
                        column: x => x.LogisticsDepartmentId,
                        principalTable: "LogisticsDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LogisticsDepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageDepartment_LogisticsDepartment_LogisticsDepartmentId",
                        column: x => x.LogisticsDepartmentId,
                        principalTable: "LogisticsDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetailSalesDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SalesDepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailSalesDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetailSalesDepartment_SalesDepartment_SalesDepartmentId",
                        column: x => x.SalesDepartmentId,
                        principalTable: "SalesDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WholesaleSalesDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SalesDepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Employees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WholesaleSalesDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WholesaleSalesDepartment_SalesDepartment_SalesDepartmentId",
                        column: x => x.SalesDepartmentId,
                        principalTable: "SalesDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ComplexObject",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "AccountingDepartment",
                columns: new[] { "Id", "ComplexObjectId", "Employees" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "CustomerServiceDepartment",
                columns: new[] { "Id", "ComplexObjectId", "Employees" },
                values: new object[] { 1, 1, 11 });

            migrationBuilder.InsertData(
                table: "ProductionDepartment",
                columns: new[] { "Id", "ComplexObjectId", "Employees" },
                values: new object[] { 1, 1, 7 });

            migrationBuilder.InsertData(
                table: "EngineeringDepartment",
                columns: new[] { "Id", "Employees", "ProductionDepartmentId" },
                values: new object[] { 1, 4, 1 });

            migrationBuilder.InsertData(
                table: "LogisticsDepartment",
                columns: new[] { "Id", "CustomerServiceDepartmentId", "Employees" },
                values: new object[] { 1, 1, 7 });

            migrationBuilder.InsertData(
                table: "PurchasingDepartment",
                columns: new[] { "Id", "Employees", "ProductionDepartmentId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "QualityControlDepartment",
                columns: new[] { "Id", "Employees", "ProductionDepartmentId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "SalesDepartment",
                columns: new[] { "Id", "CustomerServiceDepartmentId", "Employees" },
                values: new object[] { 1, 1, 4 });

            migrationBuilder.InsertData(
                table: "DeliveryDepartment",
                columns: new[] { "Id", "Employees", "LogisticsDepartmentId" },
                values: new object[] { 1, 5, 1 });

            migrationBuilder.InsertData(
                table: "RetailSalesDepartment",
                columns: new[] { "Id", "Employees", "SalesDepartmentId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "StorageDepartment",
                columns: new[] { "Id", "Employees", "LogisticsDepartmentId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "WholesaleSalesDepartment",
                columns: new[] { "Id", "Employees", "SalesDepartmentId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingDepartment_ComplexObjectId",
                table: "AccountingDepartment",
                column: "ComplexObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServiceDepartment_ComplexObjectId",
                table: "CustomerServiceDepartment",
                column: "ComplexObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDepartment_LogisticsDepartmentId",
                table: "DeliveryDepartment",
                column: "LogisticsDepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EngineeringDepartment_ProductionDepartmentId",
                table: "EngineeringDepartment",
                column: "ProductionDepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogisticsDepartment_CustomerServiceDepartmentId",
                table: "LogisticsDepartment",
                column: "CustomerServiceDepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionDepartment_ComplexObjectId",
                table: "ProductionDepartment",
                column: "ComplexObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingDepartment_ProductionDepartmentId",
                table: "PurchasingDepartment",
                column: "ProductionDepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlDepartment_ProductionDepartmentId",
                table: "QualityControlDepartment",
                column: "ProductionDepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RetailSalesDepartment_SalesDepartmentId",
                table: "RetailSalesDepartment",
                column: "SalesDepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDepartment_CustomerServiceDepartmentId",
                table: "SalesDepartment",
                column: "CustomerServiceDepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageDepartment_LogisticsDepartmentId",
                table: "StorageDepartment",
                column: "LogisticsDepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WholesaleSalesDepartment_SalesDepartmentId",
                table: "WholesaleSalesDepartment",
                column: "SalesDepartmentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingDepartment");

            migrationBuilder.DropTable(
                name: "DeliveryDepartment");

            migrationBuilder.DropTable(
                name: "EngineeringDepartment");

            migrationBuilder.DropTable(
                name: "PurchasingDepartment");

            migrationBuilder.DropTable(
                name: "QualityControlDepartment");

            migrationBuilder.DropTable(
                name: "RetailSalesDepartment");

            migrationBuilder.DropTable(
                name: "StorageDepartment");

            migrationBuilder.DropTable(
                name: "WholesaleSalesDepartment");

            migrationBuilder.DropTable(
                name: "ProductionDepartment");

            migrationBuilder.DropTable(
                name: "LogisticsDepartment");

            migrationBuilder.DropTable(
                name: "SalesDepartment");

            migrationBuilder.DropTable(
                name: "CustomerServiceDepartment");

            migrationBuilder.DropTable(
                name: "ComplexObject");
        }
    }
}
