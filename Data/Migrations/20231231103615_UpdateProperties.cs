using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webapp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Properties",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBathrooms",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBedrooms",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SquareFootage",
                table: "Properties",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NumberOfBathrooms",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NumberOfBedrooms",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SquareFootage",
                table: "Properties");
        }
    }
}
