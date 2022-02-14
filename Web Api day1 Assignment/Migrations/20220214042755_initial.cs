using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Api_day1_Assignment.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produces",
                columns: table => new
                {
                    ProduceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produces", x => x.ProduceID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "ProduceSuppliers",
                columns: table => new
                {
                    ProduceID = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduceSuppliers", x => new { x.ProduceID, x.SupplierID });
                    table.ForeignKey(
                        name: "FK_ProduceSuppliers_Produces_ProduceID",
                        column: x => x.ProduceID,
                        principalTable: "Produces",
                        principalColumn: "ProduceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProduceSuppliers_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Produces",
                columns: new[] { "ProduceID", "Description" },
                values: new object[,]
                {
                    { 1, "Oranges" },
                    { 2, "Apples" },
                    { 3, "Peaches" },
                    { 4, "Strawberries" },
                    { 5, "Watermelon" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "SupplierName" },
                values: new object[,]
                {
                    { 1, "Kin's Market" },
                    { 2, "Fresh Street Market" },
                    { 3, "Fresh Street Market" },
                    { 4, "Fresh Street Market" },
                    { 5, "Fresh Street Market" }
                });

            migrationBuilder.InsertData(
                table: "ProduceSuppliers",
                columns: new[] { "ProduceID", "SupplierID", "Qty" },
                values: new object[,]
                {
                    { 1, 1, 25 },
                    { 2, 2, 12 },
                    { 3, 2, 12 },
                    { 4, 2, 12 },
                    { 5, 2, 12 },
                    { 1, 3, 12 },
                    { 2, 4, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProduceSuppliers_SupplierID",
                table: "ProduceSuppliers",
                column: "SupplierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduceSuppliers");

            migrationBuilder.DropTable(
                name: "Produces");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
