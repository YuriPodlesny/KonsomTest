using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Konsom.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateReminders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Reminders_ReminderId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ReminderId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ReminderId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "ReminderTag",
                columns: table => new
                {
                    ReminderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderTag", x => new { x.ReminderId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ReminderTag_Reminders_ReminderId",
                        column: x => x.ReminderId,
                        principalTable: "Reminders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReminderTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReminderTag_TagId",
                table: "ReminderTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReminderTag");

            migrationBuilder.AddColumn<Guid>(
                name: "ReminderId",
                table: "Tags",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ReminderId",
                table: "Tags",
                column: "ReminderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Reminders_ReminderId",
                table: "Tags",
                column: "ReminderId",
                principalTable: "Reminders",
                principalColumn: "Id");
        }
    }
}
