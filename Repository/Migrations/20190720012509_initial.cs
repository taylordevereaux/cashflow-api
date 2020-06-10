using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashFlow.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CashFlow");

            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "CashFlow",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RecurrenceAmount = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    RecurrenceType = table.Column<string>(unicode: false, maxLength: 7, nullable: false),
                    DayOfMonth = table.Column<int>(nullable: true),
                    Ordinal = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    DayOfWeek = table.Column<string>(unicode: false, maxLength: 9, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(GetDate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "AccountType",
                schema: "Lookup",
                columns: table => new
                {
                    AccountTypeId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    AccountTypeConstant = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(GetDate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.AccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                schema: "Lookup",
                columns: table => new
                {
                    TransactionTypeId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    TransactionTypeConstant = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(GetDate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.TransactionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "CashFlow",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    AccountTypeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(20, 6)", nullable: false),
                    StartingAmount = table.Column<decimal>(type: "decimal(20, 6)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(GetDate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_AccountType_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalSchema: "Lookup",
                        principalTable: "AccountType",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecurringTransaction",
                schema: "CashFlow",
                columns: table => new
                {
                    RecurringTransactionId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    TransactionTypeId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    ScheduleId = table.Column<Guid>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(20, 6)", nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(GetDate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringTransaction", x => x.RecurringTransactionId);
                    table.ForeignKey(
                        name: "FK_RecurringTransaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "CashFlow",
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecurringTransaction_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "CashFlow",
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecurringTransaction_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalSchema: "Lookup",
                        principalTable: "TransactionType",
                        principalColumn: "TransactionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "CashFlow",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    TransactionTypeId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(20, 6)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(GetDate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "CashFlow",
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalSchema: "Lookup",
                        principalTable: "TransactionType",
                        principalColumn: "TransactionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "AccountType",
                columns: new[] { "AccountTypeId", "AccountTypeConstant", "Name" },
                values: new object[] { new Guid("b86863a3-db66-46e7-87af-bf2a49d66ff9"), "CREDIT", "Credit" });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "AccountType",
                columns: new[] { "AccountTypeId", "AccountTypeConstant", "Name" },
                values: new object[] { new Guid("2920127b-999c-455e-8536-e65ceab8552c"), "CHEQUING", "Chequing" });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "AccountType",
                columns: new[] { "AccountTypeId", "AccountTypeConstant", "Name" },
                values: new object[] { new Guid("c83c4b41-21d2-461a-a85f-f930f65ba561"), "SAVINGS", "Savings" });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "TransactionType",
                columns: new[] { "TransactionTypeId", "Name", "TransactionTypeConstant" },
                values: new object[] { new Guid("b47deace-4c2e-4f43-9125-8f78409ed8c2"), "Income", "INCOME" });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "TransactionType",
                columns: new[] { "TransactionTypeId", "Name", "TransactionTypeConstant" },
                values: new object[] { new Guid("12a56df0-d4de-4462-885e-bcce46dda838"), "Expense", "EXPENSE" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountTypeId",
                schema: "CashFlow",
                table: "Account",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringTransaction_AccountId",
                schema: "CashFlow",
                table: "RecurringTransaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringTransaction_ScheduleId",
                schema: "CashFlow",
                table: "RecurringTransaction",
                column: "ScheduleId",
                unique: true,
                filter: "[ScheduleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringTransaction_TransactionTypeId",
                schema: "CashFlow",
                table: "RecurringTransaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                schema: "CashFlow",
                table: "Transaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionTypeId",
                schema: "CashFlow",
                table: "Transaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountType_AccountTypeConstant",
                schema: "Lookup",
                table: "AccountType",
                column: "AccountTypeConstant",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionType_TransactionTypeConstant",
                schema: "Lookup",
                table: "TransactionType",
                column: "TransactionTypeConstant",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RecurringTransaction",
                schema: "CashFlow");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "CashFlow");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "CashFlow");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "CashFlow");

            migrationBuilder.DropTable(
                name: "TransactionType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "AccountType",
                schema: "Lookup");
        }
    }
}
