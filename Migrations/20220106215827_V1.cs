using Microsoft.EntityFrameworkCore.Migrations;

namespace restoran.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dezert",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeDezerta = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dezert", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jela",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeJela = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jela", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BrojTelefona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Piće",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePica = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piće", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Narudzbina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DezertID = table.Column<int>(type: "int", nullable: true),
                    JelaID = table.Column<int>(type: "int", nullable: true),
                    KlijentID = table.Column<int>(type: "int", nullable: true),
                    PicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Narudzbina_Dezert_DezertID",
                        column: x => x.DezertID,
                        principalTable: "Dezert",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbina_Jela_JelaID",
                        column: x => x.JelaID,
                        principalTable: "Jela",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbina_Klijent_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbina_Piće_PicaID",
                        column: x => x.PicaID,
                        principalTable: "Piće",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbina_DezertID",
                table: "Narudzbina",
                column: "DezertID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbina_JelaID",
                table: "Narudzbina",
                column: "JelaID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbina_KlijentID",
                table: "Narudzbina",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbina_PicaID",
                table: "Narudzbina",
                column: "PicaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Narudzbina");

            migrationBuilder.DropTable(
                name: "Dezert");

            migrationBuilder.DropTable(
                name: "Jela");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Piće");
        }
    }
}
