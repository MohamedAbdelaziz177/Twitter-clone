using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.Migrations
{
    /// <inheritdoc />
    public partial class Adding_more_types_to_notifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FollowId",
                table: "Notification",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LikeId",
                table: "Notification",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_FollowId",
                table: "Notification",
                column: "FollowId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_LikeId",
                table: "Notification",
                column: "LikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Follows_FollowId",
                table: "Notification",
                column: "FollowId",
                principalTable: "Follows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Likes_LikeId",
                table: "Notification",
                column: "LikeId",
                principalTable: "Likes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Follows_FollowId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Likes_LikeId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_FollowId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_LikeId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "FollowId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "LikeId",
                table: "Notification");
        }
    }
}
