using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelos.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DtoProducts",
                columns: table => new
                {
                    idProducts = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoProducts", x => x.idProducts);
                });

            migrationBuilder.CreateTable(
                name: "DtoSellOrders",
                columns: table => new
                {
                    idOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoSellOrders", x => x.idOrder);
                });

            migrationBuilder.CreateTable(
                name: "DtoUsers",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoUsers", x => x.idUser);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DtoProducts");

            migrationBuilder.DropTable(
                name: "DtoSellOrders");

            migrationBuilder.DropTable(
                name: "DtoUsers");
        }
    }
}
