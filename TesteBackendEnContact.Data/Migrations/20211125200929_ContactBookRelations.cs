using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteBackendEnContact.Data.Migrations
{
    public partial class ContactBookRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "ContactBooks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactBooks_CompanyId",
                table: "ContactBooks",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactBooks_Companies_CompanyId",
                table: "ContactBooks",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactBooks_Companies_CompanyId",
                table: "ContactBooks");

            migrationBuilder.DropIndex(
                name: "IX_ContactBooks_CompanyId",
                table: "ContactBooks");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ContactBooks");
        }
    }
}
