using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1_413.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "taskResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    task = table.Column<string>(nullable: true),
                    dueDate = table.Column<string>(nullable: true),
                    quadrant = table.Column<int>(nullable: false),
                    completed = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_taskResponses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Category" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Category" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Category" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Category" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "taskResponses",
                columns: new[] { "Id", "CategoryId", "completed", "dueDate", "quadrant", "task" },
                values: new object[] { 1, 1, false, "2009-01-01", 1, "test" });

            migrationBuilder.CreateIndex(
                name: "IX_taskResponses_CategoryId",
                table: "taskResponses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taskResponses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
