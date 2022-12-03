using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NftTracker.Migrations
{
    public partial class CreateNftTracker : Migration
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
                name: "Nfts",
                columns: table => new
                {
                    NftID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nfts", x => x.NftID);
                    table.ForeignKey(
                        name: "FK_Nfts_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 1, "Crypto Punks" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 2, "Bored Apes" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 3, "CloneX" });

            migrationBuilder.InsertData(
                table: "Nfts",
                columns: new[] { "NftID", "CategoryID", "Code", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "1190", "CryptoPunk #1190", 516796.00m },
                    { 2, 1, "5217", "CryptoPunk #5217", 2906977.50m },
                    { 3, 1, "7804", "CryptoPunk #7804", 5426358.00m },
                    { 4, 2, "550", "#550", 239018.15m },
                    { 5, 2, "3439", "#3439", 1936693.01m },
                    { 6, 2, "2488", "#2488", 245077.58m },
                    { 7, 3, "5549", "CloneX #5549", 43062.03m },
                    { 8, 3, "1677", "CloneX #1677", 63307.51m },
                    { 9, 3, "14433", "CloneX #14433", 178294.62m },
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nfts_CategoryID",
                table: "Nfts",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nfts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
