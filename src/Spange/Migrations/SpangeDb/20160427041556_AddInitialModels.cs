using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Spange.Migrations.SpangeDb
{
    public partial class AddInitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camps",
                columns: table => new
                {
                    CampId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BedDescription = table.Column<string>(nullable: true),
                    CampDescription = table.Column<string>(nullable: true),
                    CampPrice = table.Column<double>(nullable: false),
                    Fire = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    PitchCampId = table.Column<int>(nullable: false),
                    Public = table.Column<int>(nullable: false),
                    Thieves = table.Column<int>(nullable: false),
                    WaterProof = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camp", x => x.CampId);
                });
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GutterPrice = table.Column<double>(nullable: false),
                    HpBonus = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PlayerFoodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.FoodId);
                });
            migrationBuilder.CreateTable(
                name: "Gears",
                columns: table => new
                {
                    GearId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CookBonus = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GutterPrice = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PitchBonus = table.Column<int>(nullable: false),
                    StreetPrice = table.Column<double>(nullable: false),
                    SympathyBonus = table.Column<int>(nullable: false),
                    ThreatBonus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gear", x => x.GearId);
                });
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Appeal = table.Column<int>(nullable: false),
                    CurrentHp = table.Column<int>(nullable: false),
                    Hunger = table.Column<int>(nullable: false),
                    MaxHp = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NeedToSleep = table.Column<int>(nullable: false),
                    Spange = table.Column<double>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                });
            migrationBuilder.CreateTable(
                name: "Spots",
                columns: table => new
                {
                    SpotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimSpotId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImgLink = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Pockets = table.Column<int>(nullable: false),
                    SpangeyPockets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spot", x => x.SpotId);
                });
            migrationBuilder.CreateTable(
                name: "ClaimSpots",
                columns: table => new
                {
                    ClaimSpotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(nullable: false),
                    SpotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimSpot", x => x.ClaimSpotId);
                    table.ForeignKey(
                        name: "FK_ClaimSpot_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppealBonus = table.Column<string>(nullable: true),
                    CookBonus = table.Column<int>(nullable: false),
                    Damage = table.Column<int>(nullable: false),
                    GutterPrice = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PlayerId = table.Column<int>(nullable: false),
                    SleepBonus = table.Column<int>(nullable: false),
                    StreetPrice = table.Column<double>(nullable: false),
                    ThreatBonus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => x.DrugId);
                    table.ForeignKey(
                        name: "FK_Drug_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "PitchCamps",
                columns: table => new
                {
                    PitchCampId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CampId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitchCamp", x => x.PitchCampId);
                    table.ForeignKey(
                        name: "FK_PitchCamp_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "PlayerFoods",
                columns: table => new
                {
                    PlayerFoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerFood", x => x.PlayerFoodId);
                    table.ForeignKey(
                        name: "FK_PlayerFood_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Camps");
            migrationBuilder.DropTable("ClaimSpots");
            migrationBuilder.DropTable("Drugs");
            migrationBuilder.DropTable("Foods");
            migrationBuilder.DropTable("Gears");
            migrationBuilder.DropTable("PitchCamps");
            migrationBuilder.DropTable("PlayerFoods");
            migrationBuilder.DropTable("Spots");
            migrationBuilder.DropTable("Players");
        }
    }
}
