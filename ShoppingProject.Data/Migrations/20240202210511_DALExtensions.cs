using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingProject.Data.Migrations
{
    public partial class DALExtensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("154339ef-14b2-4c67-8706-525d8988c500"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eac6e9f8-f8ab-496a-a613-4e7fc675ad8a"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a99ad62-b618-4dca-a254-5843255ab008"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 3, 0, 5, 10, 832, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9ec7d5a6-ee4a-4f21-885a-21a89e95559d"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 3, 0, 5, 10, 832, DateTimeKind.Local).AddTicks(1433));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2399fb31-9b98-4933-8681-3d6972de53d7"), new Guid("9a99ad62-b618-4dca-a254-5843255ab008"), "Admin Test", new DateTime(2024, 2, 3, 0, 5, 10, 832, DateTimeKind.Local).AddTicks(1584), null, null, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", false, null, null, "Polo Yaka Kazak", 1500m, 200 },
                    { new Guid("33916a30-d643-47f7-b422-cd519dc1befe"), new Guid("9ec7d5a6-ee4a-4f21-885a-21a89e95559d"), "Admin Test", new DateTime(2024, 2, 3, 0, 5, 10, 832, DateTimeKind.Local).AddTicks(1589), null, null, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", false, null, null, "Polo Yaka T-Shirt", 500m, 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2399fb31-9b98-4933-8681-3d6972de53d7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33916a30-d643-47f7-b422-cd519dc1befe"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a99ad62-b618-4dca-a254-5843255ab008"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 2, 18, 28, 11, 843, DateTimeKind.Local).AddTicks(4304));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9ec7d5a6-ee4a-4f21-885a-21a89e95559d"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 2, 18, 28, 11, 843, DateTimeKind.Local).AddTicks(4309));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("154339ef-14b2-4c67-8706-525d8988c500"), new Guid("9a99ad62-b618-4dca-a254-5843255ab008"), "Admin Test", new DateTime(2024, 2, 2, 18, 28, 11, 843, DateTimeKind.Local).AddTicks(4465), null, null, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", false, null, null, "Polo Yaka Kazak", 1500m, 200 },
                    { new Guid("eac6e9f8-f8ab-496a-a613-4e7fc675ad8a"), new Guid("9ec7d5a6-ee4a-4f21-885a-21a89e95559d"), "Admin Test", new DateTime(2024, 2, 2, 18, 28, 11, 843, DateTimeKind.Local).AddTicks(4470), null, null, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", false, null, null, "Polo Yaka T-Shirt", 500m, 100 }
                });
        }
    }
}
