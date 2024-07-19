using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedLocationInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locationInfos_Cities_CityId",
                table: "locationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_locationInfos_Countries_CountryId",
                table: "locationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_locationInfos_States_StateId",
                table: "locationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_locationInfos_TrainInfos_TrainInfoId",
                table: "locationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_locationInfos_Users_UserId",
                table: "locationInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_locationInfos",
                table: "locationInfos");

            migrationBuilder.RenameTable(
                name: "locationInfos",
                newName: "LocationInfo");

            migrationBuilder.RenameIndex(
                name: "IX_locationInfos_UserId",
                table: "LocationInfo",
                newName: "IX_LocationInfo_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_locationInfos_TrainInfoId",
                table: "LocationInfo",
                newName: "IX_LocationInfo_TrainInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_locationInfos_StateId",
                table: "LocationInfo",
                newName: "IX_LocationInfo_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_locationInfos_CountryId",
                table: "LocationInfo",
                newName: "IX_LocationInfo_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_locationInfos_CityId",
                table: "LocationInfo",
                newName: "IX_LocationInfo_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationInfo",
                table: "LocationInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationInfo_Cities_CityId",
                table: "LocationInfo",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationInfo_Countries_CountryId",
                table: "LocationInfo",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationInfo_States_StateId",
                table: "LocationInfo",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationInfo_TrainInfos_TrainInfoId",
                table: "LocationInfo",
                column: "TrainInfoId",
                principalTable: "TrainInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationInfo_Users_UserId",
                table: "LocationInfo",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationInfo_Cities_CityId",
                table: "LocationInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationInfo_Countries_CountryId",
                table: "LocationInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationInfo_States_StateId",
                table: "LocationInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationInfo_TrainInfos_TrainInfoId",
                table: "LocationInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationInfo_Users_UserId",
                table: "LocationInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationInfo",
                table: "LocationInfo");

            migrationBuilder.RenameTable(
                name: "LocationInfo",
                newName: "locationInfos");

            migrationBuilder.RenameIndex(
                name: "IX_LocationInfo_UserId",
                table: "locationInfos",
                newName: "IX_locationInfos_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationInfo_TrainInfoId",
                table: "locationInfos",
                newName: "IX_locationInfos_TrainInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationInfo_StateId",
                table: "locationInfos",
                newName: "IX_locationInfos_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationInfo_CountryId",
                table: "locationInfos",
                newName: "IX_locationInfos_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationInfo_CityId",
                table: "locationInfos",
                newName: "IX_locationInfos_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_locationInfos",
                table: "locationInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_locationInfos_Cities_CityId",
                table: "locationInfos",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_locationInfos_Countries_CountryId",
                table: "locationInfos",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_locationInfos_States_StateId",
                table: "locationInfos",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_locationInfos_TrainInfos_TrainInfoId",
                table: "locationInfos",
                column: "TrainInfoId",
                principalTable: "TrainInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_locationInfos_Users_UserId",
                table: "locationInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
