using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedAppyInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "JobPostId",
                table: "ApplyInfos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ApplyInfos_JobPostId",
                table: "ApplyInfos",
                column: "JobPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyInfos_JobPosts_JobPostId",
                table: "ApplyInfos",
                column: "JobPostId",
                principalTable: "JobPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyInfos_JobPosts_JobPostId",
                table: "ApplyInfos");

            migrationBuilder.DropIndex(
                name: "IX_ApplyInfos_JobPostId",
                table: "ApplyInfos");

            migrationBuilder.DropColumn(
                name: "JobPostId",
                table: "ApplyInfos");
        }
    }
}
