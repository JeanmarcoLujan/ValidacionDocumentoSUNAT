using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUNATValidation.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purcharses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaComp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoComp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerieComp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumComp = table.Column<int>(type: "int", nullable: false),
                    TipoDocSN = table.Column<int>(type: "int", nullable: true),
                    NumDocSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocTotal = table.Column<double>(type: "float", nullable: false),
                    DocRate = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purcharses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Purchase = table.Column<double>(type: "float", nullable: false),
                    Sale = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rates_DateRate",
                table: "Rates",
                column: "DateRate",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purcharses");

            migrationBuilder.DropTable(
                name: "Rates");
        }
    }
}
