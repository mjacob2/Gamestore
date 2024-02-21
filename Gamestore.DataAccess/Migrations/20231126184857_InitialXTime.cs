using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gamestore.DataAccess.Migrations;

/// <inheritdoc />
public partial class InitialXTime : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                CategoryID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.CategoryID);
            });

        migrationBuilder.CreateTable(
            name: "Genres",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                ParentGenreId = table.Column<int>(type: "int", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Genres", x => x.Id);
                table.ForeignKey(
                    name: "FK_Genres_Genres_ParentGenreId",
                    column: x => x.ParentGenreId,
                    principalTable: "Genres",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Orders",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                Sum = table.Column<int>(type: "int", nullable: false),
                Discount = table.Column<float>(type: "real", nullable: false),
                TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ShipCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ShipPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ShipRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ShipCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ShipAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ShipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Freight = table.Column<double>(type: "float", nullable: false),
                ShipVia = table.Column<int>(type: "int", nullable: false),
                ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Platforms",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Platforms", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Publisher",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                HomePage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Publisher", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Shippers",
            columns: table => new
            {
                ShipperId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Shippers", x => x.ShipperId);
            });

        migrationBuilder.CreateTable(
            name: "Suppliers",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ContactTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                HomePage = table.Column<string>(type: "nvarchar(max)", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Suppliers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                ProductID = table.Column<int>(type: "int", nullable: false),
                ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                SupplierID = table.Column<int>(type: "int", nullable: false),
                CategoryID = table.Column<int>(type: "int", nullable: false),
                QuantityPerUnit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                UnitsInStock = table.Column<int>(type: "int", nullable: false),
                UnitsOnOrder = table.Column<int>(type: "int", nullable: false),
                ReorderLevel = table.Column<int>(type: "int", nullable: false),
                Discontinued = table.Column<bool>(type: "bit", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
                table.ForeignKey(
                    name: "FK_Products_Categories_CategoryID",
                    column: x => x.CategoryID,
                    principalTable: "Categories",
                    principalColumn: "CategoryID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "OrderItems",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false),
                ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                OrderId = table.Column<int>(type: "int", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrderItems", x => x.Id);
                table.ForeignKey(
                    name: "FK_OrderItems_Orders_OrderId",
                    column: x => x.OrderId,
                    principalTable: "Orders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Games",
            columns: table => new
            {
                GameAlias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                UnitInStock = table.Column<int>(type: "int", nullable: false),
                Discontinued = table.Column<bool>(type: "bit", nullable: false),
                PlatformId = table.Column<int>(type: "int", nullable: false),
                PublisherId = table.Column<int>(type: "int", nullable: false),
                ViewCount = table.Column<int>(type: "int", nullable: false),
                PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Games", x => x.GameAlias);
                table.ForeignKey(
                    name: "FK_Games_Publisher_PublisherId",
                    column: x => x.PublisherId,
                    principalTable: "Publisher",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Comments",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AuthorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Body = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                BanUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                GameAlias = table.Column<string>(type: "nvarchar(100)", nullable: false),
                UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                AsReplyToCommentId = table.Column<int>(type: "int", nullable: true),
                AsQuoteToCommentId = table.Column<int>(type: "int", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Comments", x => x.Id);
                table.ForeignKey(
                    name: "FK_Comments_Games_GameAlias",
                    column: x => x.GameAlias,
                    principalTable: "Games",
                    principalColumn: "GameAlias",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "GameGenre",
            columns: table => new
            {
                GamesGameAlias = table.Column<string>(type: "nvarchar(100)", nullable: false),
                GenresId = table.Column<int>(type: "int", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GameGenre", x => new { x.GamesGameAlias, x.GenresId });
                table.ForeignKey(
                    name: "FK_GameGenre_Games_GamesGameAlias",
                    column: x => x.GamesGameAlias,
                    principalTable: "Games",
                    principalColumn: "GameAlias",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_GameGenre_Genres_GenresId",
                    column: x => x.GenresId,
                    principalTable: "Genres",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "GamePlatform",
            columns: table => new
            {
                GamesGameAlias = table.Column<string>(type: "nvarchar(100)", nullable: false),
                PlatformsId = table.Column<int>(type: "int", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GamePlatform", x => new { x.GamesGameAlias, x.PlatformsId });
                table.ForeignKey(
                    name: "FK_GamePlatform_Games_GamesGameAlias",
                    column: x => x.GamesGameAlias,
                    principalTable: "Games",
                    principalColumn: "GameAlias",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_GamePlatform_Platforms_PlatformsId",
                    column: x => x.PlatformsId,
                    principalTable: "Platforms",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Comments_GameAlias",
            table: "Comments",
            column: "GameAlias");

        migrationBuilder.CreateIndex(
            name: "IX_GameGenre_GenresId",
            table: "GameGenre",
            column: "GenresId");

        migrationBuilder.CreateIndex(
            name: "IX_GamePlatform_PlatformsId",
            table: "GamePlatform",
            column: "PlatformsId");

        migrationBuilder.CreateIndex(
            name: "IX_Games_PublisherId",
            table: "Games",
            column: "PublisherId");

        migrationBuilder.CreateIndex(
            name: "IX_Genres_Name",
            table: "Genres",
            column: "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Genres_ParentGenreId",
            table: "Genres",
            column: "ParentGenreId");

        migrationBuilder.CreateIndex(
            name: "IX_OrderItems_OrderId",
            table: "OrderItems",
            column: "OrderId");

        migrationBuilder.CreateIndex(
            name: "IX_Platforms_Type",
            table: "Platforms",
            column: "Type",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Products_CategoryID",
            table: "Products",
            column: "CategoryID");

        migrationBuilder.CreateIndex(
            name: "IX_Publisher_CompanyName",
            table: "Publisher",
            column: "CompanyName",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Comments");

        migrationBuilder.DropTable(
            name: "GameGenre");

        migrationBuilder.DropTable(
            name: "GamePlatform");

        migrationBuilder.DropTable(
            name: "OrderItems");

        migrationBuilder.DropTable(
            name: "Products");

        migrationBuilder.DropTable(
            name: "Shippers");

        migrationBuilder.DropTable(
            name: "Suppliers");

        migrationBuilder.DropTable(
            name: "Genres");

        migrationBuilder.DropTable(
            name: "Games");

        migrationBuilder.DropTable(
            name: "Platforms");

        migrationBuilder.DropTable(
            name: "Orders");

        migrationBuilder.DropTable(
            name: "Categories");

        migrationBuilder.DropTable(
            name: "Publisher");
    }
}
