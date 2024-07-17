using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrainInfoName",
                table: "TrainInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GenderName",
                table: "Genders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmploymentTypeName",
                table: "EmploymentTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTypes_WorkTypeName",
                table: "WorkTypes",
                column: "WorkTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainInfos_TrainInfoName",
                table: "TrainInfos",
                column: "TrainInfoName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_StateName",
                table: "States",
                column: "StateName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ShiftName",
                table: "Shifts",
                column: "ShiftName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageName",
                table: "Languages",
                column: "LanguageName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genders_GenderName",
                table: "Genders",
                column: "GenderName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentTypes_EmploymentTypeName",
                table: "EmploymentTypes",
                column: "EmploymentTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryName",
                table: "Countries",
                column: "CountryName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkTypes_WorkTypeName",
                table: "WorkTypes");

            migrationBuilder.DropIndex(
                name: "IX_TrainInfos_TrainInfoName",
                table: "TrainInfos");

            migrationBuilder.DropIndex(
                name: "IX_States_StateName",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_ShiftName",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageName",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Genders_GenderName",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentTypes_EmploymentTypeName",
                table: "EmploymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CountryName",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "TrainInfoName",
                table: "TrainInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "GenderName",
                table: "Genders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmploymentTypeName",
                table: "EmploymentTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
