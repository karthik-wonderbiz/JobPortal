using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_shifts",
                table: "shifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_languages",
                table: "languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genders",
                table: "genders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_countries",
                table: "countries");

            migrationBuilder.RenameTable(
                name: "shifts",
                newName: "Shifts");

            migrationBuilder.RenameTable(
                name: "languages",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "genders",
                newName: "Genders");

            migrationBuilder.RenameTable(
                name: "countries",
                newName: "Countries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genders",
                table: "Genders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genders",
                table: "Genders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Shifts",
                newName: "shifts");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "languages");

            migrationBuilder.RenameTable(
                name: "Genders",
                newName: "genders");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "countries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shifts",
                table: "shifts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_languages",
                table: "languages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genders",
                table: "genders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_countries",
                table: "countries",
                column: "Id");
        }
    }
}
