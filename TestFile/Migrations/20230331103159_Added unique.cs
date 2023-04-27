using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestFile.Migrations
{
    /// <inheritdoc />
    public partial class Addedunique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Images_Title",
                table: "Images",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_Title",
                table: "Images");
        }
    }
}
