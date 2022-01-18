using Microsoft.EntityFrameworkCore.Migrations;

namespace restoran.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestoranID",
                table: "Piće",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestoranID",
                table: "Narudzbina",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestoranID",
                table: "Jela",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestoranID",
                table: "Dezert",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Restoran",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeRestorana = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restoran", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piće_RestoranID",
                table: "Piće",
                column: "RestoranID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbina_RestoranID",
                table: "Narudzbina",
                column: "RestoranID");

            migrationBuilder.CreateIndex(
                name: "IX_Jela_RestoranID",
                table: "Jela",
                column: "RestoranID");

            migrationBuilder.CreateIndex(
                name: "IX_Dezert_RestoranID",
                table: "Dezert",
                column: "RestoranID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dezert_Restoran_RestoranID",
                table: "Dezert",
                column: "RestoranID",
                principalTable: "Restoran",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jela_Restoran_RestoranID",
                table: "Jela",
                column: "RestoranID",
                principalTable: "Restoran",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbina_Restoran_RestoranID",
                table: "Narudzbina",
                column: "RestoranID",
                principalTable: "Restoran",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piće_Restoran_RestoranID",
                table: "Piće",
                column: "RestoranID",
                principalTable: "Restoran",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dezert_Restoran_RestoranID",
                table: "Dezert");

            migrationBuilder.DropForeignKey(
                name: "FK_Jela_Restoran_RestoranID",
                table: "Jela");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbina_Restoran_RestoranID",
                table: "Narudzbina");

            migrationBuilder.DropForeignKey(
                name: "FK_Piće_Restoran_RestoranID",
                table: "Piće");

            migrationBuilder.DropTable(
                name: "Restoran");

            migrationBuilder.DropIndex(
                name: "IX_Piće_RestoranID",
                table: "Piće");

            migrationBuilder.DropIndex(
                name: "IX_Narudzbina_RestoranID",
                table: "Narudzbina");

            migrationBuilder.DropIndex(
                name: "IX_Jela_RestoranID",
                table: "Jela");

            migrationBuilder.DropIndex(
                name: "IX_Dezert_RestoranID",
                table: "Dezert");

            migrationBuilder.DropColumn(
                name: "RestoranID",
                table: "Piće");

            migrationBuilder.DropColumn(
                name: "RestoranID",
                table: "Narudzbina");

            migrationBuilder.DropColumn(
                name: "RestoranID",
                table: "Jela");

            migrationBuilder.DropColumn(
                name: "RestoranID",
                table: "Dezert");
        }
    }
}
