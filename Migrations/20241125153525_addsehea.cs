using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereToGoTonight.Migrations
{
    /// <inheritdoc />
    public partial class addsehea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WhereToGoSchema");

            migrationBuilder.RenameTable(
                name: "UserPreferences",
                newName: "UserPreferences",
                newSchema: "WhereToGoSchema");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Ratings",
                newSchema: "WhereToGoSchema");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "Places",
                newSchema: "WhereToGoSchema");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "WhereToGoSchema");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "WhereToGoSchema");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "WhereToGoSchema");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "WhereToGoSchema");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "WhereToGoSchema");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "WhereToGoSchema");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "WhereToGoSchema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserPreferences",
                schema: "WhereToGoSchema",
                newName: "UserPreferences");

            migrationBuilder.RenameTable(
                name: "Ratings",
                schema: "WhereToGoSchema",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "Places",
                schema: "WhereToGoSchema",
                newName: "Places");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "WhereToGoSchema",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "WhereToGoSchema",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "WhereToGoSchema",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "WhereToGoSchema",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "WhereToGoSchema",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "WhereToGoSchema",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "WhereToGoSchema",
                newName: "AspNetRoleClaims");
        }
    }
}
