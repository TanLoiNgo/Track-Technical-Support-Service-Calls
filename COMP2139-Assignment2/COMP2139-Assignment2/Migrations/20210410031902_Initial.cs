using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMP2139_Assignment1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearlyPrice = table.Column<double>(type: "float", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    City = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    State = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => new { x.CustomerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Registrations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Australia" },
                    { 2, "Brazil" },
                    { 3, "Canada" },
                    { 4, "France" },
                    { 5, "Germany" },
                    { 6, "USA" },
                    { 7, "Vietnam" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "Name", "ReleasedDate", "YearlyPrice" },
                values: new object[,]
                {
                    { 1, "TRNY10", "Tournament Master 1.0", new DateTime(2015, 1, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 4.9900000000000002 },
                    { 2, "LEAG10", "League Scheduler 1.0", new DateTime(2016, 5, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 4.9900000000000002 },
                    { 3, "LEAGD", "League Scheduler Deluxe 1.0", new DateTime(2017, 1, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 7.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "alison@sportsprosoftware.com", "Alison Diaz", "800 555 0443" },
                    { 2, "AWilson@sportsprosoftware.com", "Andrew Wilson", "800 555 9999" },
                    { 3, "GFiori@sportsprosoftware.com", "Gina Fiori", "800 555 7777" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "55 Lapp St", "San Francisco", 1, "kanthoni@gpe.com", "Kaitlyn", "Anthoni", "416 555 1111", "M6N 3W5", "LA" },
                    { 2, "55 Lapp St", "Washington", 1, "ania@mma.nidc.com", "Ania", "Irvin", "416 547 3543", "M6N 3W5", "LA" },
                    { 3, "71 Lapp St", "Toronto", 3, "Zoon@mma.nidc.com", "Gonzaloo", "Keeton", "416 547 5555", "M6N 3W5", "ON" },
                    { 4, "111 Lapp St", "Toronto", 3, "King@mma.nidc.com", "King", "Kee", "416 547 9999", "M6N 3W5", "ON" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "CustomerId", "DateClosed", "DateOpened", "Description", "ProductId", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program fails with error code 510, unable to open database", 1, 1, "Error launching program" },
                    { 4, 2, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program fails with error code 510, unable to open database", 2, null, "Error launching program" },
                    { 2, 3, null, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program fails with error code 500, unable to open database", 2, 2, "Could not install" },
                    { 3, 3, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program fails with error code 510, unable to open database", 3, null, "Error importing data" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "CustomerId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomerId",
                table: "Incidents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductId",
                table: "Incidents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianId",
                table: "Incidents",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ProductId",
                table: "Registrations",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
