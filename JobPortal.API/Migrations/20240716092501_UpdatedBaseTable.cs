using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_employmentTypes",
                table: "employmentTypes");

            migrationBuilder.RenameTable(
                name: "employmentTypes",
                newName: "EmploymentTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmploymentTypes",
                table: "EmploymentTypes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmploymentTypes",
                table: "EmploymentTypes");

            migrationBuilder.RenameTable(
                name: "EmploymentTypes",
                newName: "employmentTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employmentTypes",
                table: "employmentTypes",
                column: "Id");
        }
    }
}
