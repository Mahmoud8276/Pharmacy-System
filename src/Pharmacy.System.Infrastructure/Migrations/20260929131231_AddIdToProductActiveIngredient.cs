using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy.System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToProductActiveIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductActiveIngredients",
                table: "ProductActiveIngredients");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductActiveIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductActiveIngredients",
                table: "ProductActiveIngredients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductActiveIngredients_ProductId_ActiveIngredientId",
                table: "ProductActiveIngredients",
                columns: new[] { "ProductId", "ActiveIngredientId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductActiveIngredients",
                table: "ProductActiveIngredients");

            migrationBuilder.DropIndex(
                name: "IX_ProductActiveIngredients_ProductId_ActiveIngredientId",
                table: "ProductActiveIngredients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductActiveIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductActiveIngredients",
                table: "ProductActiveIngredients",
                columns: new[] { "ProductId", "ActiveIngredientId" });
        }
    }
}
