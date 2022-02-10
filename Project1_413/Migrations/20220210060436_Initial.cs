using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1_413.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TaskResponses",
                columns: table => new
                {
                    Task = table.Column<string>(nullable: false),
                    DueDate = table.Column<string>(nullable: true),
                    Quadrant = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskResponses", x => x.Task);
                    table.ForeignKey(
                        name: "FK_TaskResponses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "TaskResponses",
                columns: new[] { "Task", "CategoryId", "Completed", "DueDate", "Quadrant" },
                values: new object[] { "test", 1, false, "2009-01-01", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TaskResponses_CategoryId",
                table: "TaskResponses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskResponses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
