using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedRecruiter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recruiters");
        }
    }
}
