using Microsoft.EntityFrameworkCore.Migrations;

namespace ClothDonationApp.Migrations
{
    public partial class IdTypeChangeDonation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_AspNetUsers_ApplicationUserId1",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_ApplicationUserId1",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Donations");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Donations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Donations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DonarName",
                table: "Donations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Donations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Donations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Donations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ApplicationUserId",
                table: "Donations",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_AspNetUsers_ApplicationUserId",
                table: "Donations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_AspNetUsers_ApplicationUserId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_ApplicationUserId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Donations");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DonarName",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Donations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Donations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ApplicationUserId1",
                table: "Donations",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_AspNetUsers_ApplicationUserId1",
                table: "Donations",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
