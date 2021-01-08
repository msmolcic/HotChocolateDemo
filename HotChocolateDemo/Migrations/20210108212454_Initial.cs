using Microsoft.EntityFrameworkCore.Migrations;

namespace HotChocolateDemo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SharedId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SharedId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Borrowers",
                columns: new[] { "Id", "Name", "SharedId" },
                values: new object[] { 1, "Adam", 1 });

            migrationBuilder.InsertData(
                table: "Borrowers",
                columns: new[] { "Id", "Name", "SharedId" },
                values: new object[] { 2, "Mike", 1 });

            migrationBuilder.InsertData(
                table: "Borrowers",
                columns: new[] { "Id", "Name", "SharedId" },
                values: new object[] { 3, "Luke", 2 });

            migrationBuilder.InsertData(
                table: "Borrowers",
                columns: new[] { "Id", "Name", "SharedId" },
                values: new object[] { 4, "Sean", 2 });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "Amount", "SharedId" },
                values: new object[] { 1, 100m, 1 });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "Amount", "SharedId" },
                values: new object[] { 2, 150m, 1 });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "Amount", "SharedId" },
                values: new object[] { 3, 200m, 2 });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "Amount", "SharedId" },
                values: new object[] { 4, 220m, 2 });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "Amount", "SharedId" },
                values: new object[] { 5, 270m, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrowers");

            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
