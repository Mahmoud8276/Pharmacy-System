using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy.System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitFamilyAndModelsConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CanoncialUnitId",
                table: "BaseUnits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitFamilyId",
                table: "BaseUnits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UnitFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriptoin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitFamilies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseUnits_CanoncialUnitId",
                table: "BaseUnits",
                column: "CanoncialUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseUnits_UnitFamilyId",
                table: "BaseUnits",
                column: "UnitFamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseUnits_BaseUnits_CanoncialUnitId",
                table: "BaseUnits",
                column: "CanoncialUnitId",
                principalTable: "BaseUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseUnits_UnitFamilies_UnitFamilyId",
                table: "BaseUnits",
                column: "UnitFamilyId",
                principalTable: "UnitFamilies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseUnits_BaseUnits_CanoncialUnitId",
                table: "BaseUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseUnits_UnitFamilies_UnitFamilyId",
                table: "BaseUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "UnitFamilies");

            migrationBuilder.DropIndex(
                name: "IX_Products_Barcode",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_BaseUnits_CanoncialUnitId",
                table: "BaseUnits");

            migrationBuilder.DropIndex(
                name: "IX_BaseUnits_UnitFamilyId",
                table: "BaseUnits");

            migrationBuilder.DropColumn(
                name: "CanoncialUnitId",
                table: "BaseUnits");

            migrationBuilder.DropColumn(
                name: "UnitFamilyId",
                table: "BaseUnits");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
