using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Spange.Migrations.SpangeDb
{
    public partial class AddImageLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ClaimSpot_Player_PlayerId", table: "ClaimSpots");
            migrationBuilder.DropForeignKey(name: "FK_Drug_Player_PlayerId", table: "Drugs");
            migrationBuilder.DropForeignKey(name: "FK_PitchCamp_Player_PlayerId", table: "PitchCamps");
            migrationBuilder.DropForeignKey(name: "FK_PlayerFood_Player_PlayerId", table: "PlayerFoods");
            migrationBuilder.DropColumn(name: "Hunger", table: "Players");
            migrationBuilder.DropColumn(name: "NeedToSleep", table: "Players");
            migrationBuilder.AddColumn<string>(
                name: "ImgLink",
                table: "Players",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "Satiation",
                table: "Players",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Sleep",
                table: "Players",
                nullable: false,
                defaultValue: 0);
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
            migrationBuilder.DropColumn(name: "ImgLink", table: "Players");
            migrationBuilder.DropColumn(name: "Satiation", table: "Players");
            migrationBuilder.DropColumn(name: "Sleep", table: "Players");
            migrationBuilder.AddColumn<int>(
                name: "Hunger",
                table: "Players",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "NeedToSleep",
                table: "Players",
                nullable: false,
                defaultValue: 0);
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
