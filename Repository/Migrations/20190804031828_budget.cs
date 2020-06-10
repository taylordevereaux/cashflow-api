using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashFlow.Api.Migrations
{
    public partial class budget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Budget");

            migrationBuilder.EnsureSchema(
                name: "UBudget");

            migrationBuilder.CreateTable(
                name: "Bucket",
                schema: "Budget",
                columns: table => new
                {
                    BucketId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    BucketConstant = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(5, 4)", nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(GetDate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bucket", x => x.BucketId);
                });

            migrationBuilder.CreateTable(
                name: "UserBucket",
                schema: "UBudget",
                columns: table => new
                {
                    UserBucketId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Percentage = table.Column<decimal>(type: "decimal(5, 4)", nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BucketId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBucket", x => x.UserBucketId);
                    table.ForeignKey(
                        name: "FK_UserBucket_Bucket_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Budget",
                        principalTable: "Bucket",
                        principalColumn: "BucketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBucket_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                schema: "UBudget",
                columns: table => new
                {
                    LineItemId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    IsIncome = table.Column<bool>(nullable: false),
                    FixedAmount = table.Column<decimal>(type: "decimal(20, 6)", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserBucketId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.LineItemId);
                    table.ForeignKey(
                        name: "FK_LineItem_UserBucket_UserBucketId",
                        column: x => x.UserBucketId,
                        principalSchema: "UBudget",
                        principalTable: "UserBucket",
                        principalColumn: "UserBucketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItem_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Budget",
                table: "Bucket",
                columns: new[] { "BucketId", "BucketConstant", "Description", "Name", "Percentage" },
                values: new object[] { new Guid("7dacd09d-ea60-47e3-a256-44d6648ec31a"), "FIXEDCOSTS", "(cell phone, rent, utilities)", "Fixed Costs", 0.60m });

            migrationBuilder.InsertData(
                schema: "Budget",
                table: "Bucket",
                columns: new[] { "BucketId", "BucketConstant", "Description", "Name", "Percentage" },
                values: new object[] { new Guid("4c6d99b8-3af2-4dc6-8976-353ec9940275"), "INVESTMENTS", "(RRSP, 401k, Tax-Free Savings, Roth IRA)", "Investments", 0.05m });

            migrationBuilder.InsertData(
                schema: "Budget",
                table: "Bucket",
                columns: new[] { "BucketId", "BucketConstant", "Description", "Name", "Percentage" },
                values: new object[] { new Guid("8cdaf6b9-6f66-4699-b689-c88ba1ded997"), "SAVINGS", "(wedding, vacation, house down payment)", "Savings", 0.1m });

            migrationBuilder.InsertData(
                schema: "Budget",
                table: "Bucket",
                columns: new[] { "BucketId", "BucketConstant", "Description", "Name", "Percentage" },
                values: new object[] { new Guid("71aee0f2-b303-44df-8b48-5d9b8a33ca52"), "GUILTFREE", "(restaurants, bars, movies)", "Guilt Free Spending", 0.25m });

            migrationBuilder.CreateIndex(
                name: "IX_Bucket_BucketConstant",
                schema: "Budget",
                table: "Bucket",
                column: "BucketConstant",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_UserBucketId",
                schema: "UBudget",
                table: "LineItem",
                column: "UserBucketId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_UserId",
                schema: "UBudget",
                table: "LineItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBucket_BucketId",
                schema: "UBudget",
                table: "UserBucket",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBucket_UserId",
                schema: "UBudget",
                table: "UserBucket",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem",
                schema: "UBudget");

            migrationBuilder.DropTable(
                name: "UserBucket",
                schema: "UBudget");

            migrationBuilder.DropTable(
                name: "Bucket",
                schema: "Budget");
        }
    }
}
