using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StatusLkpId",
                table: "sub_activities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryLkpId",
                table: "activities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StatusLkpId",
                table: "activities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sub_activities_activity_id",
                table: "sub_activities",
                column: "activity_id");

            migrationBuilder.CreateIndex(
                name: "IX_sub_activities_StatusLkpId",
                table: "sub_activities",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_activities_CategoryLkpId",
                table: "activities",
                column: "CategoryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_activities_StatusLkpId",
                table: "activities",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_activities_category_lkp_CategoryLkpId",
                table: "activities",
                column: "CategoryLkpId",
                principalTable: "category_lkp",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_activities_status_lkp_StatusLkpId",
                table: "activities",
                column: "StatusLkpId",
                principalTable: "status_lkp",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sub_activities_activities_activity_id",
                table: "sub_activities",
                column: "activity_id",
                principalTable: "activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sub_activities_status_lkp_StatusLkpId",
                table: "sub_activities",
                column: "StatusLkpId",
                principalTable: "status_lkp",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activities_category_lkp_CategoryLkpId",
                table: "activities");

            migrationBuilder.DropForeignKey(
                name: "FK_activities_status_lkp_StatusLkpId",
                table: "activities");

            migrationBuilder.DropForeignKey(
                name: "FK_sub_activities_activities_activity_id",
                table: "sub_activities");

            migrationBuilder.DropForeignKey(
                name: "FK_sub_activities_status_lkp_StatusLkpId",
                table: "sub_activities");

            migrationBuilder.DropIndex(
                name: "IX_sub_activities_activity_id",
                table: "sub_activities");

            migrationBuilder.DropIndex(
                name: "IX_sub_activities_StatusLkpId",
                table: "sub_activities");

            migrationBuilder.DropIndex(
                name: "IX_activities_CategoryLkpId",
                table: "activities");

            migrationBuilder.DropIndex(
                name: "IX_activities_StatusLkpId",
                table: "activities");

            migrationBuilder.DropColumn(
                name: "StatusLkpId",
                table: "sub_activities");

            migrationBuilder.DropColumn(
                name: "CategoryLkpId",
                table: "activities");

            migrationBuilder.DropColumn(
                name: "StatusLkpId",
                table: "activities");
        }
    }
}
