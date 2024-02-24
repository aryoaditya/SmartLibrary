using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_books",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<string>(type: "nchar(6)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    edition = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    publisher = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    copies = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_books", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_members",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<string>(type: "nchar(6)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_members", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_staffs",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<string>(type: "nchar(6)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_staffs", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    otp = table.Column<int>(type: "int", nullable: false),
                    is_used = table.Column<bool>(type: "bit", nullable: false),
                    expired_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_members_guid",
                        column: x => x.guid,
                        principalTable: "tb_m_members",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_staffs_guid",
                        column: x => x.guid,
                        principalTable: "tb_m_staffs",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_return_records",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    member_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    staff_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    borrow_record_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    return_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_return_records", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_return_records_tb_m_members_member_guid",
                        column: x => x.member_guid,
                        principalTable: "tb_m_members",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_return_records_tb_m_staffs_staff_guid",
                        column: x => x.staff_guid,
                        principalTable: "tb_m_staffs",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_account_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_account_roles", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_account_roles_tb_m_accounts_account_guid",
                        column: x => x.account_guid,
                        principalTable: "tb_m_accounts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_account_roles_tb_m_roles_role_guid",
                        column: x => x.role_guid,
                        principalTable: "tb_m_roles",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_book_returns",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    return_record_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    book_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_book_returns", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_book_returns_tb_m_books_book_guid",
                        column: x => x.book_guid,
                        principalTable: "tb_m_books",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_book_returns_tb_m_return_records_return_record_guid",
                        column: x => x.return_record_guid,
                        principalTable: "tb_m_return_records",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_borrower_records",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    member_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    staff_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date_request = table.Column<DateTime>(type: "datetime2", nullable: false),
                    borrow_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    return_deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_borrower_records", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_borrower_records_tb_m_members_member_guid",
                        column: x => x.member_guid,
                        principalTable: "tb_m_members",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_borrower_records_tb_m_return_records_guid",
                        column: x => x.guid,
                        principalTable: "tb_m_return_records",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_m_borrower_records_tb_m_staffs_staff_guid",
                        column: x => x.staff_guid,
                        principalTable: "tb_m_staffs",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_book_borrowers",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    borrower_record_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    book_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_book_borrowers", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_book_borrowers_tb_m_books_book_guid",
                        column: x => x.book_guid,
                        principalTable: "tb_m_books",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_book_borrowers_tb_m_borrower_records_borrower_record_guid",
                        column: x => x.borrower_record_guid,
                        principalTable: "tb_m_borrower_records",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_account_roles_account_guid",
                table: "tb_m_account_roles",
                column: "account_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_account_roles_role_guid",
                table: "tb_m_account_roles",
                column: "role_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_book_borrowers_book_guid",
                table: "tb_m_book_borrowers",
                column: "book_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_book_borrowers_borrower_record_guid",
                table: "tb_m_book_borrowers",
                column: "borrower_record_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_book_returns_book_guid",
                table: "tb_m_book_returns",
                column: "book_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_book_returns_return_record_guid",
                table: "tb_m_book_returns",
                column: "return_record_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_borrower_records_member_guid",
                table: "tb_m_borrower_records",
                column: "member_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_borrower_records_staff_guid",
                table: "tb_m_borrower_records",
                column: "staff_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_members_email",
                table: "tb_m_members",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_members_id",
                table: "tb_m_members",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_members_phone_number",
                table: "tb_m_members",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_return_records_member_guid",
                table: "tb_m_return_records",
                column: "member_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_return_records_staff_guid",
                table: "tb_m_return_records",
                column: "staff_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_staffs_email",
                table: "tb_m_staffs",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_staffs_id",
                table: "tb_m_staffs",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_staffs_phone_number",
                table: "tb_m_staffs",
                column: "phone_number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_account_roles");

            migrationBuilder.DropTable(
                name: "tb_m_book_borrowers");

            migrationBuilder.DropTable(
                name: "tb_m_book_returns");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_m_borrower_records");

            migrationBuilder.DropTable(
                name: "tb_m_books");

            migrationBuilder.DropTable(
                name: "tb_m_return_records");

            migrationBuilder.DropTable(
                name: "tb_m_members");

            migrationBuilder.DropTable(
                name: "tb_m_staffs");
        }
    }
}
