using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ThirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status_id",
                table: "sub_activities",
                newName: "status_lkp_id");

            migrationBuilder.RenameColumn(
                name: "status_id",
                table: "activities",
                newName: "status_lkp_id");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "activities",
                newName: "category_lkp_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status_lkp_id",
                table: "sub_activities",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "status_lkp_id",
                table: "activities",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "category_lkp_id",
                table: "activities",
                newName: "category_id");
        }
    }
}
