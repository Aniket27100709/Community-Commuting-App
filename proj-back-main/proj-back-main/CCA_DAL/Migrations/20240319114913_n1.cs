using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCA_DAL.Migrations
{
    /// <inheritdoc />
    public partial class n1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    feeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    averageInKm = table.Column<int>(type: "int", nullable: false),
                    wearTearCost = table.Column<int>(type: "int", nullable: false),
                    drivercharges = table.Column<int>(type: "int", nullable: false),
                    carPoolCommision = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.feeId);
                });

            migrationBuilder.CreateTable(
                name: "RideProvides",
                columns: table => new
                {
                    rpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    adharcard = table.Column<long>(type: "bigint", maxLength: 12, nullable: false),
                    emailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dlNo = table.Column<string>(type: "nchar(18)", fixedLength: true, maxLength: 18, nullable: false),
                    validUpto = table.Column<DateOnly>(type: "date", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    birthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideProvides", x => x.rpId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    tripId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    creatorUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rideDate = table.Column<DateOnly>(type: "date", nullable: false),
                    rideTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    rideStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noOfSeat = table.Column<int>(type: "int", nullable: false),
                    seatsFilled = table.Column<int>(type: "int", nullable: false),
                    fromLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toLoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.tripId);
                });

            migrationBuilder.CreateTable(
                name: "billMasters",
                columns: table => new
                {
                    billId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    rideId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    noOfKm = table.Column<int>(type: "int", nullable: false),
                    totalbill = table.Column<int>(type: "int", nullable: false),
                    noOfOccupants = table.Column<int>(type: "int", nullable: false),
                    feeId = table.Column<int>(type: "int", nullable: false),
                    costPerOccupant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billMasters", x => x.billId);
                    table.ForeignKey(
                        name: "FK_billMasters_Fees_feeId",
                        column: x => x.feeId,
                        principalTable: "Fees",
                        principalColumn: "feeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RideInfos",
                columns: table => new
                {
                    vehicleNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    rpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    carType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideInfos", x => x.vehicleNo);
                    table.ForeignKey(
                        name: "FK_RideInfos_RideProvides_rpId",
                        column: x => x.rpId,
                        principalTable: "RideProvides",
                        principalColumn: "rpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    bookingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tripId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    numberOfSeat = table.Column<int>(type: "int", nullable: false),
                    seekerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.bookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Trips_tripId",
                        column: x => x.tripId,
                        principalTable: "Trips",
                        principalColumn: "tripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smiles",
                columns: table => new
                {
                    smileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    occupancy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smiles", x => x.smileId);
                    table.ForeignKey(
                        name: "FK_Smiles_RideInfos_rpId",
                        column: x => x.rpId,
                        principalTable: "RideInfos",
                        principalColumn: "vehicleNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_billMasters_feeId",
                table: "billMasters",
                column: "feeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_tripId",
                table: "Bookings",
                column: "tripId");

            migrationBuilder.CreateIndex(
                name: "IX_RideInfos_rpId",
                table: "RideInfos",
                column: "rpId");

            migrationBuilder.CreateIndex(
                name: "IX_Smiles_rpId",
                table: "Smiles",
                column: "rpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "billMasters");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Smiles");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "RideInfos");

            migrationBuilder.DropTable(
                name: "RideProvides");
        }
    }
}
