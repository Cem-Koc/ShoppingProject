using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingProject.Data.Migrations
{
    public partial class SeedCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { new Guid("9a99ad62-b618-4dca-a254-5843255ab008"), "Admin Test", new DateTime(2024, 2, 2, 18, 28, 11, 843, DateTimeKind.Local).AddTicks(4304), null, null, false, null, null, "Kazak" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { new Guid("9ec7d5a6-ee4a-4f21-885a-21a89e95559d"), "Admin Test", new DateTime(2024, 2, 2, 18, 28, 11, 843, DateTimeKind.Local).AddTicks(4309), null, null, false, null, null, "T-Shirt" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("154339ef-14b2-4c67-8706-525d8988c500"), new Guid("9a99ad62-b618-4dca-a254-5843255ab008"), "Admin Test", new DateTime(2024, 2, 2, 18, 28, 11, 843, DateTimeKind.Local).AddTicks(4465), null, null, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", false, null, null, "Polo Yaka Kazak", 1500m, 200 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("eac6e9f8-f8ab-496a-a613-4e7fc675ad8a"), new Guid("9ec7d5a6-ee4a-4f21-885a-21a89e95559d"), "Admin Test", new DateTime(2024, 2, 2, 18, 28, 11, 843, DateTimeKind.Local).AddTicks(4470), null, null, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", false, null, null, "Polo Yaka T-Shirt", 500m, 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("154339ef-14b2-4c67-8706-525d8988c500"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eac6e9f8-f8ab-496a-a613-4e7fc675ad8a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a99ad62-b618-4dca-a254-5843255ab008"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9ec7d5a6-ee4a-4f21-885a-21a89e95559d"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
