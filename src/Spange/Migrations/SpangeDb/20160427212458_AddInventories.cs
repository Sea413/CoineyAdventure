using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Spange.Migrations.SpangeDb
{
    public partial class AddInventories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ClaimSpot_Player_PlayerId", table: "ClaimSpots");
            migrationBuilder.DropForeignKey(name: "FK_Drug_Player_PlayerId", table: "Drugs");
            migrationBuilder.DropForeignKey(name: "FK_PitchCamp_Player_PlayerId", table: "PitchCamps");
            migrationBuilder.DropForeignKey(name: "FK_PlayerFood_Player_PlayerId", table: "PlayerFoods");
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GearId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_ClaimSpot_Player_PlayerId",
                table: "ClaimSpots",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Drug_Player_PlayerId",
                table: "Drugs",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_PitchCamp_Player_PlayerId",
                table: "PitchCamps",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_PlayerFood_Player_PlayerId",
                table: "PlayerFoods",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ClaimSpot_Player_PlayerId", table: "ClaimSpots");
            migrationBuilder.DropForeignKey(name: "FK_Drug_Player_PlayerId", table: "Drugs");
            migrationBuilder.DropForeignKey(name: "FK_PitchCamp_Player_PlayerId", table: "PitchCamps");
            migrationBuilder.DropForeignKey(name: "FK_PlayerFood_Player_PlayerId", table: "PlayerFoods");
            migrationBuilder.DropTable("Inventories");
            migrationBuilder.AddForeignKey(
                name: "FK_ClaimSpot_Player_PlayerId",
                table: "ClaimSpots",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Drug_Player_PlayerId",
                table: "Drugs",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_PitchCamp_Player_PlayerId",
                table: "PitchCamps",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_PlayerFood_Player_PlayerId",
                table: "PlayerFoods",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
