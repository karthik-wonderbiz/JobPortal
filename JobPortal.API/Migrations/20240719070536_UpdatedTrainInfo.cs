using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTrainInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationInfo_TrainInfos_TrainInfoId",
                table: "LocationInfo");

            migrationBuilder.DropTable(
                name: "TrainInfos");

            migrationBuilder.RenameColumn(
                name: "TrainInfoId",
                table: "LocationInfo",
                newName: "TrainLineId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationInfo_TrainInfoId",
                table: "LocationInfo",
                newName: "IX_LocationInfo_TrainLineId");

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    QualificationId = table.Column<long>(type: "bigint", nullable: false),
                    InstituteName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BoardOrUniversityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DegreeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GradeOrPercentage = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainLines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainLineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrainLineCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainLines", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_QualificationId",
                table: "Educations",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_UserId",
                table: "Educations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainLines_TrainLineName",
                table: "TrainLines",
                column: "TrainLineName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationInfo_TrainLines_TrainLineId",
                table: "LocationInfo",
                column: "TrainLineId",
                principalTable: "TrainLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationInfo_TrainLines_TrainLineId",
                table: "LocationInfo");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "TrainLines");

            migrationBuilder.RenameColumn(
                name: "TrainLineId",
                table: "LocationInfo",
                newName: "TrainInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationInfo_TrainLineId",
                table: "LocationInfo",
                newName: "IX_LocationInfo_TrainInfoId");

            migrationBuilder.CreateTable(
                name: "TrainInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TrainInfoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainInfoName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainInfos_TrainInfoName",
                table: "TrainInfos",
                column: "TrainInfoName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationInfo_TrainInfos_TrainInfoId",
                table: "LocationInfo",
                column: "TrainInfoId",
                principalTable: "TrainInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
