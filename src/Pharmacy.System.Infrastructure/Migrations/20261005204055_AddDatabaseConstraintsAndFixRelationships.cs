using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy.System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabaseConstraintsAndFixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductActiveIngredients_ActiveIngredients_ActiveIngredientId",
                table: "ProductActiveIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPackagingLevels_PackagingUnits_PackagingUnitId",
                table: "ProductPackagingLevels");

            migrationBuilder.DropIndex(
                name: "IX_ProductPackagingLevels_ProductId",
                table: "ProductPackagingLevels");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "BaseUnits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackagingLevels_ProductId_PackagingUnitId",
                table: "ProductPackagingLevels",
                columns: new[] { "ProductId", "PackagingUnitId" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_ProductPackagingLevels_QuantityOfChildPackage",
                table: "ProductPackagingLevels",
                sql: "[QuantityOfChildPackage] >= 1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductActiveIngredients_ActiveIngredients_ActiveIngredientId",
                table: "ProductActiveIngredients",
                column: "ActiveIngredientId",
                principalTable: "ActiveIngredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPackagingLevels_PackagingUnits_PackagingUnitId",
                table: "ProductPackagingLevels",
                column: "PackagingUnitId",
                principalTable: "PackagingUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductActiveIngredients_ActiveIngredients_ActiveIngredientId",
                table: "ProductActiveIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPackagingLevels_PackagingUnits_PackagingUnitId",
                table: "ProductPackagingLevels");

            migrationBuilder.DropIndex(
                name: "IX_ProductPackagingLevels_ProductId_PackagingUnitId",
                table: "ProductPackagingLevels");

            migrationBuilder.DropCheckConstraint(
                name: "CK_ProductPackagingLevels_QuantityOfChildPackage",
                table: "ProductPackagingLevels");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "BaseUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackagingLevels_ProductId",
                table: "ProductPackagingLevels",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductActiveIngredients_ActiveIngredients_ActiveIngredientId",
                table: "ProductActiveIngredients",
                column: "ActiveIngredientId",
                principalTable: "ActiveIngredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPackagingLevels_PackagingUnits_PackagingUnitId",
                table: "ProductPackagingLevels",
                column: "PackagingUnitId",
                principalTable: "PackagingUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
