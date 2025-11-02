using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KYC_Cache_Service.Migrations
{
    /// <inheritdoc />
    public partial class DbModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "KYCItems");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "PersonalDetails");

            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "PersonalDetails",
                newName: "Data_SurName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "PersonalDetails",
                newName: "Data_FirstName");

            migrationBuilder.AddColumn<DateTime>(
                name: "CachedAt",
                table: "PersonalDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CachedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CachedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Preferred = table.Column<bool>(type: "bit", nullable: false),
                    Data_EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYCItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KYCFormId = table.Column<int>(type: "int", nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CachedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYCItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CachedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Preferred = table.Column<bool>(type: "bit", nullable: false),
                    Data_Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "KYCItem");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropColumn(
                name: "CachedAt",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "SSN",
                table: "PersonalDetails");

            migrationBuilder.RenameColumn(
                name: "Data_SurName",
                table: "PersonalDetails",
                newName: "SurName");

            migrationBuilder.RenameColumn(
                name: "Data_FirstName",
                table: "PersonalDetails",
                newName: "FirstName");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "PersonalDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preferred = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYCItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    KYCFormId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYCItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preferred = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                });
        }
    }
}
