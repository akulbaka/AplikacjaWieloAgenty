using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaWieloAgenty.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Klawiatura = table.Column<int>(type: "INTEGER", nullable: false),
                    Pad = table.Column<int>(type: "INTEGER", nullable: false),
                    Kierownica = table.Column<int>(type: "INTEGER", nullable: false),
                    Niski = table.Column<int>(type: "INTEGER", nullable: false),
                    Sredni = table.Column<int>(type: "INTEGER", nullable: false),
                    Trudny = table.Column<int>(type: "INTEGER", nullable: false),
                    BardzoTrudny = table.Column<int>(type: "INTEGER", nullable: false),
                    Rally = table.Column<int>(type: "INTEGER", nullable: false),
                    Sportowe = table.Column<int>(type: "INTEGER", nullable: false),
                    OpenWheel = table.Column<int>(type: "INTEGER", nullable: false),
                    Brak = table.Column<int>(type: "INTEGER", nullable: false),
                    AI = table.Column<int>(type: "INTEGER", nullable: false),
                    Online = table.Column<int>(type: "INTEGER", nullable: false),
                    Nie = table.Column<int>(type: "INTEGER", nullable: false),
                    Tak = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
