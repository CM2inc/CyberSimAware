using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarShop.Migrations
{
    public partial class CreateGuitarShop : Migration
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
                values: new object[] { 1, "Guitars" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 2, "Basses" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 3, "Drums" });

            migrationBuilder.InsertData(
                table: "Nfts",
                columns: new[] { "NftID", "CategoryID", "Code", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "strat", "Fender Stratocaster", 699m },
                    { 2, 1, "les_paul", "Gibson Les Paul", 1199m },
                    { 3, 1, "sg", "Gibson SG", 2517m },
                    { 4, 1, "fg700s", "Yamaha FG700S", 489.99m },
                    { 5, 1, "washburn", "Washburn D10S", 299m },
                    { 6, 1, "rodriguez", "Rodriguez Caballero 11", 415m },
                    { 7, 2, "precision", "Fender Precision", 799.99m },
                    { 8, 2, "hofner", "Hofner Icon", 499.99m },
                    { 9, 3, "ludwig", "Ludwig 5-piece Drum Set with Cymbals", 699.99m },
                    { 10, 3, "tama", "Tama 5-Piece Drum Set with Cymbals", 799.99m }
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
