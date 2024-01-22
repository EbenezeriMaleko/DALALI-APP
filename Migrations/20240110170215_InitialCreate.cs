using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webapp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentTable",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfBedrooms = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfBathrooms = table.Column<int>(type: "INTEGER", nullable: false),
                    SquareFootage = table.Column<double>(type: "REAL", nullable: false),
                    ImageData = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentTable", x => x.PropertyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentTable");
        }
    }
}
