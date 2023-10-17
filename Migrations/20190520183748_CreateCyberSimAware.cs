using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberSimAware.Migrations
{
    public partial class CreateCyberSimAware : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Sims",
                columns: table => new
                {
                    SimID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Abstract = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sims", x => x.SimID);
                    table.ForeignKey(
                        name: "FK_Sims_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 1, "Ransomware" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 2, "Phishing" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 3, "Social Engineering" });

            migrationBuilder.InsertData(
                table: "Sims",
                columns: new[] { "SimID", "CategoryID", "Code", "Name", "Abstract" },
                values: new object[,]
                //Hardcoded in values for the lifecycles
                {
                    { 1, 1, "1", "CryptoPunk #1190", "" },
                    { 2, 1, "2", "CryptoPunk #5217", "" },
                    { 3, 1, "3", "CryptoPunk #7804", "" },
                    { 4, 2, "4", "#550", "" },
                    { 5, 2, "5", "#3439", "" },
                    { 6, 2, "6", "#2488", "" },
                    { 7, 3, "7", "CloneX #5549", "" },
                    { 8, 3, "8", "CloneX #1677", "" },
                    { 9, 3, "9", "CloneX #14433", "" },
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sims_CategoryID",
                table: "Sims",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sims");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
