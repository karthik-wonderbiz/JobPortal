using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_certificationInfos_Users_UserId",
                table: "certificationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_urlInfos_UrlNames_UrlNameId",
                table: "urlInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_urlInfos_Users_UserId",
                table: "urlInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_urlInfos",
                table: "urlInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_certificationInfos",
                table: "certificationInfos");

            migrationBuilder.RenameTable(
                name: "urlInfos",
                newName: "UrlInfos");

            migrationBuilder.RenameTable(
                name: "certificationInfos",
                newName: "CertificationInfos");

            migrationBuilder.RenameIndex(
                name: "IX_urlInfos_UserId",
                table: "UrlInfos",
                newName: "IX_UrlInfos_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_urlInfos_UrlNameId",
                table: "UrlInfos",
                newName: "IX_UrlInfos_UrlNameId");

            migrationBuilder.RenameIndex(
                name: "IX_certificationInfos_UserId",
                table: "CertificationInfos",
                newName: "IX_CertificationInfos_UserId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "PersonalInfos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "PersonalInfos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrlInfos",
                table: "UrlInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificationInfos",
                table: "CertificationInfos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplyInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplyInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPersons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyInfoId = table.Column<long>(type: "bigint", nullable: false),
                    ContactPersonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPersonPhone = table.Column<long>(type: "bigint", maxLength: 100, nullable: false),
                    ContactPersonEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPersons_Companies_CompanyInfoId",
                        column: x => x.CompanyInfoId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recruiters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyInfoId = table.Column<long>(type: "bigint", nullable: false),
                    RecruiterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RecruiterPhone = table.Column<long>(type: "bigint", maxLength: 100, nullable: false),
                    RecruiterEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recruiters_Companies_CompanyInfoId",
                        column: x => x.CompanyInfoId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyInfos_UserId",
                table: "ApplyInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_CompanyInfoId",
                table: "ContactPersons",
                column: "CompanyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_ContactPersonEmail",
                table: "ContactPersons",
                column: "ContactPersonEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_ContactPersonPhone",
                table: "ContactPersons",
                column: "ContactPersonPhone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recruiters_CompanyInfoId",
                table: "Recruiters",
                column: "CompanyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruiters_RecruiterEmail",
                table: "Recruiters",
                column: "RecruiterEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recruiters_RecruiterPhone",
                table: "Recruiters",
                column: "RecruiterPhone",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationInfos_Users_UserId",
                table: "CertificationInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UrlInfos_UrlNames_UrlNameId",
                table: "UrlInfos",
                column: "UrlNameId",
                principalTable: "UrlNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UrlInfos_Users_UserId",
                table: "UrlInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificationInfos_Users_UserId",
                table: "CertificationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UrlInfos_UrlNames_UrlNameId",
                table: "UrlInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UrlInfos_Users_UserId",
                table: "UrlInfos");

            migrationBuilder.DropTable(
                name: "ApplyInfos");

            migrationBuilder.DropTable(
                name: "ContactPersons");

            migrationBuilder.DropTable(
                name: "Recruiters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrlInfos",
                table: "UrlInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificationInfos",
                table: "CertificationInfos");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "PersonalInfos");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "PersonalInfos");

            migrationBuilder.RenameTable(
                name: "UrlInfos",
                newName: "urlInfos");

            migrationBuilder.RenameTable(
                name: "CertificationInfos",
                newName: "certificationInfos");

            migrationBuilder.RenameIndex(
                name: "IX_UrlInfos_UserId",
                table: "urlInfos",
                newName: "IX_urlInfos_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UrlInfos_UrlNameId",
                table: "urlInfos",
                newName: "IX_urlInfos_UrlNameId");

            migrationBuilder.RenameIndex(
                name: "IX_CertificationInfos_UserId",
                table: "certificationInfos",
                newName: "IX_certificationInfos_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_urlInfos",
                table: "urlInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_certificationInfos",
                table: "certificationInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_certificationInfos_Users_UserId",
                table: "certificationInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_urlInfos_UrlNames_UrlNameId",
                table: "urlInfos",
                column: "UrlNameId",
                principalTable: "UrlNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_urlInfos_Users_UserId",
                table: "urlInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
