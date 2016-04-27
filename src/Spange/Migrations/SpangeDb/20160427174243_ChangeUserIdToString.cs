using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Spange.Migrations.SpangeDb
{
    public partial class ChangeUserIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ClaimSpot_Player_PlayerId", table: "ClaimSpots");
            migrationBuilder.DropForeignKey(name: "FK_Drug_Player_PlayerId", table: "Drugs");
            migrationBuilder.DropForeignKey(name: "FK_PitchCamp_Player_PlayerId", table: "PitchCamps");
            migrationBuilder.DropForeignKey(name: "FK_PlayerFood_Player_PlayerId", table: "PlayerFoods");
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Players",
                nullable: true);
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
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Players",
                nullable: false);
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
