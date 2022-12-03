using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2CWebsite.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CatID = table.Column<int>(type: "int", nullable: false),
                    CatName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Levels = table.Column<int>(type: "int", nullable: true),
                    Ordering = table.Column<int>(type: "int", nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: true),
                    Thumb = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaCover = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaSchemeMarkup = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__6A1C8ADA87E24470", x => x.CatID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64B8DB55DEEF", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManuID = table.Column<int>(type: "int", nullable: false),
                    ManuName = table.Column<string>(type: "text", nullable: true),
                    ManuAddress = table.Column<string>(type: "text", nullable: true),
                    ManuPhone = table.Column<int>(type: "int", nullable: true),
                    ManuEmail = table.Column<string>(type: "text", nullable: true),
                    ManuCountry = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Manufact__4135BFA56496A086", x => x.ManuID);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageID = table.Column<int>(type: "int", nullable: false),
                    PageName = table.Column<string>(type: "text", nullable: true),
                    Contents = table.Column<string>(type: "text", nullable: true),
                    Thumb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ordering = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pages__C565B124DEBCD68C", x => x.PageID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__8AFACE3ADFFAD443", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "TransactStatus",
                columns: table => new
                {
                    TransactID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__4400DE75A0475FE7", x => x.TransactID);
                });

            migrationBuilder.CreateTable(
                name: "Supplement",
                columns: table => new
                {
                    SID = table.Column<int>(type: "int", nullable: false),
                    SName = table.Column<string>(type: "text", nullable: true),
                    SLink = table.Column<string>(type: "text", nullable: true),
                    ManuID = table.Column<int>(type: "int", nullable: true),
                    Thumb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CatID = table.Column<int>(type: "int", nullable: true),
                    Uses = table.Column<string>(type: "text", nullable: true),
                    Ingredient = table.Column<string>(type: "text", nullable: true),
                    Directions = table.Column<string>(type: "text", nullable: true),
                    Warnings = table.Column<string>(type: "text", nullable: true),
                    OtherInfo = table.Column<string>(type: "text", nullable: true),
                    InactiveIngredient = table.Column<string>(type: "text", nullable: true),
                    BestSeller = table.Column<bool>(type: "bit", nullable: true),
                    HomeFlag = table.Column<bool>(type: "bit", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Suppleme__CA1959701EC1FCBA", x => x.SID);
                    table.ForeignKey(
                        name: "FK__Supplemen__CatID__59FA5E80",
                        column: x => x.CatID,
                        principalTable: "Category",
                        principalColumn: "CatID");
                    table.ForeignKey(
                        name: "FK__Supplemen__ManuI__59063A47",
                        column: x => x.ManuID,
                        principalTable: "Manufacturer",
                        principalColumn: "ManuID");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accounts__349DA586F32C672E", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK__Accounts__RoleID__49C3F6B7",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TransactID = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentID = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__C3905BAFADC07772", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__Orders__Customer__403A8C7D",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Orders__Transact__412EB0B6",
                        column: x => x.TransactID,
                        principalTable: "TransactStatus",
                        principalColumn: "TransactID");
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    PriceID = table.Column<int>(type: "int", nullable: false),
                    SID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Price__4957584FA22168B9", x => x.PriceID);
                    table.ForeignKey(
                        name: "FK__Price__SID__5CD6CB2B",
                        column: x => x.SID,
                        principalTable: "Supplement",
                        principalColumn: "SID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    SID = table.Column<int>(type: "int", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__D3B9D30C8A92814B", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK__OrderDeta__Order__5FB337D6",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK__OrderDetail__SID__60A75C0F",
                        column: x => x.SID,
                        principalTable: "Supplement",
                        principalColumn: "SID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleID",
                table: "Accounts",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_SID",
                table: "OrderDetail",
                column: "SID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TransactID",
                table: "Orders",
                column: "TransactID");

            migrationBuilder.CreateIndex(
                name: "IX_Price_SID",
                table: "Price",
                column: "SID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_CatID",
                table: "Supplement",
                column: "CatID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_ManuID",
                table: "Supplement",
                column: "ManuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Supplement");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "TransactStatus");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
