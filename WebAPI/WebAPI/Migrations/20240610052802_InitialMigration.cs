using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriasId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriasId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Preco = table.Column<int>(type: "int", nullable: false),
                    QntEstoque = table.Column<int>(type: "int", nullable: false),
                    FK_CategoriaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_FK_CategoriaId",
                        column: x => x.FK_CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriasId");
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriasId", "Nome" },
                values: new object[] { 1L, "Eletrônicos" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "FK_CategoriaId", "Nome", "Preco", "QntEstoque" },
                values: new object[] { 1, 1L, "Smartphone", 2000, 50 });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FK_CategoriaId",
                table: "Produtos",
                column: "FK_CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
