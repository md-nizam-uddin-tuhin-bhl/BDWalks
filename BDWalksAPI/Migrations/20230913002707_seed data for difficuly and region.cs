using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDWalksAPI.Migrations
{
    public partial class seeddatafordifficulyandregion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5ba1df2a-0d81-4c68-bc46-d754068a71a5"), "Medium" },
                    { new Guid("766b3e6c-5c11-45f6-bc0d-0171a24857ff"), "Easy" },
                    { new Guid("9b99b0df-f4e6-4e7b-ae65-02ab2f5c9181"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0ce38c42-8184-4d45-96c3-be74625dcfe7"), "Dha", "Dhaka", "www.http://Dhaka.com" },
                    { new Guid("454186c6-0fdf-4fc2-8d4d-5f6d592441ba"), "Sy", "Sylhet", "www.http://Sylhet.com" },
                    { new Guid("b6433f36-693e-469c-a754-3e78a90a5534"), "Bar", "Barisal", "www.http://Barisal.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5ba1df2a-0d81-4c68-bc46-d754068a71a5"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("766b3e6c-5c11-45f6-bc0d-0171a24857ff"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9b99b0df-f4e6-4e7b-ae65-02ab2f5c9181"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("0ce38c42-8184-4d45-96c3-be74625dcfe7"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("454186c6-0fdf-4fc2-8d4d-5f6d592441ba"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("b6433f36-693e-469c-a754-3e78a90a5534"));
        }
    }
}
