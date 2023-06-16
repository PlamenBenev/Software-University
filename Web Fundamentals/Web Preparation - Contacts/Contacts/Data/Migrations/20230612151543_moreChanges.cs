using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts.Data.Migrations
{
    public partial class moreChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContact_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContact_Contacts_ContactId",
                table: "ApplicationUserContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserContact",
                table: "ApplicationUserContact");

            migrationBuilder.RenameTable(
                name: "ApplicationUserContact",
                newName: "ApplicationUsersContacts");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserContact_ContactId",
                table: "ApplicationUsersContacts",
                newName: "IX_ApplicationUsersContacts_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsersContacts",
                table: "ApplicationUsersContacts",
                columns: new[] { "ApplicationUserId", "ContactId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersContacts_AspNetUsers_ApplicationUserId",
                table: "ApplicationUsersContacts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersContacts_Contacts_ContactId",
                table: "ApplicationUsersContacts",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersContacts_AspNetUsers_ApplicationUserId",
                table: "ApplicationUsersContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersContacts_Contacts_ContactId",
                table: "ApplicationUsersContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsersContacts",
                table: "ApplicationUsersContacts");

            migrationBuilder.RenameTable(
                name: "ApplicationUsersContacts",
                newName: "ApplicationUserContact");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsersContacts_ContactId",
                table: "ApplicationUserContact",
                newName: "IX_ApplicationUserContact_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserContact",
                table: "ApplicationUserContact",
                columns: new[] { "ApplicationUserId", "ContactId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContact_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContact",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContact_Contacts_ContactId",
                table: "ApplicationUserContact",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
