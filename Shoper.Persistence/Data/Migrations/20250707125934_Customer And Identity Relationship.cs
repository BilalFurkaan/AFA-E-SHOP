using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoper.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class CustomerAndIdentityRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Customers");
        }
    }
}
