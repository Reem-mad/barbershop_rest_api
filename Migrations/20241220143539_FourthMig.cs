using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShopApi.Migrations
{
    /// <inheritdoc />
    public partial class FourthMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Barbers_BarberId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "BarberId",
                table: "Services",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Services",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "HairSaloons",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Barbers_BarberId",
                table: "Services",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Barbers_BarberId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "HairSaloons");

            migrationBuilder.AlterColumn<int>(
                name: "BarberId",
                table: "Services",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Barbers_BarberId",
                table: "Services",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id");
        }
    }
}
