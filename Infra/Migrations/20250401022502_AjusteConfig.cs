using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPedidos",
                table: "ItemPedidos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPedidos",
                table: "ItemPedidos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidos_PedidoId",
                table: "ItemPedidos",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPedidos",
                table: "ItemPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItemPedidos_PedidoId",
                table: "ItemPedidos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPedidos",
                table: "ItemPedidos",
                column: "PedidoId");
        }
    }
}
