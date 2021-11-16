using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Project.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodReviewers",
                columns: table => new
                {
                    FoodReviewerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodReviewers", x => x.FoodReviewerID);
                });

            migrationBuilder.CreateTable(
                name: "Resturants",
                columns: table => new
                {
                    ResturantID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resturants", x => x.ResturantID);
                });

            migrationBuilder.CreateTable(
                name: "ReviewResturants",
                columns: table => new
                {
                    FoodReviewerID = table.Column<int>(nullable: false),
                    ResturantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewResturants", x => new { x.ResturantID, x.FoodReviewerID });
                    table.ForeignKey(
                        name: "FK_ReviewResturants_FoodReviewers_FoodReviewerID",
                        column: x => x.FoodReviewerID,
                        principalTable: "FoodReviewers",
                        principalColumn: "FoodReviewerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewResturants_Resturants_ResturantID",
                        column: x => x.ResturantID,
                        principalTable: "Resturants",
                        principalColumn: "ResturantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewResturants_FoodReviewerID",
                table: "ReviewResturants",
                column: "FoodReviewerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewResturants");

            migrationBuilder.DropTable(
                name: "FoodReviewers");

            migrationBuilder.DropTable(
                name: "Resturants");
        }
    }
}
