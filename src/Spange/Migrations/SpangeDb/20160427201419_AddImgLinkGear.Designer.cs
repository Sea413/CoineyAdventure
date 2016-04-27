using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Spange.Models;

namespace Spange.Migrations.SpangeDb
{
    [DbContext(typeof(SpangeDbContext))]
    [Migration("20160427201419_AddImgLinkGear")]
    partial class AddImgLinkGear
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Spange.Models.Camp", b =>
                {
                    b.Property<int>("CampId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BedDescription");

                    b.Property<string>("CampDescription");

                    b.Property<double>("CampPrice");

                    b.Property<int>("Fire");

                    b.Property<string>("Location");

                    b.Property<int>("PitchCampId");

                    b.Property<int>("Public");

                    b.Property<int>("Thieves");

                    b.Property<int>("WaterProof");

                    b.HasKey("CampId");

                    b.HasAnnotation("Relational:TableName", "Camps");
                });

            modelBuilder.Entity("Spange.Models.ClaimSpot", b =>
                {
                    b.Property<int>("ClaimSpotId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerId");

                    b.Property<int>("SpotId");

                    b.HasKey("ClaimSpotId");

                    b.HasAnnotation("Relational:TableName", "ClaimSpots");
                });

            modelBuilder.Entity("Spange.Models.Drug", b =>
                {
                    b.Property<int>("DrugId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppealBonus");

                    b.Property<int>("CookBonus");

                    b.Property<int>("Damage");

                    b.Property<double>("GutterPrice");

                    b.Property<string>("Name");

                    b.Property<int>("PlayerId");

                    b.Property<int>("SleepBonus");

                    b.Property<double>("StreetPrice");

                    b.Property<string>("ThreatBonus");

                    b.HasKey("DrugId");

                    b.HasAnnotation("Relational:TableName", "Drugs");
                });

            modelBuilder.Entity("Spange.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("GutterPrice");

                    b.Property<int>("HpBonus");

                    b.Property<string>("Name");

                    b.Property<int>("PlayerFoodId");

                    b.HasKey("FoodId");

                    b.HasAnnotation("Relational:TableName", "Foods");
                });

            modelBuilder.Entity("Spange.Models.Gear", b =>
                {
                    b.Property<int>("GearId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CookBonus");

                    b.Property<string>("Description");

                    b.Property<double>("GutterPrice");

                    b.Property<string>("ImgLink");

                    b.Property<string>("Name");

                    b.Property<int>("PitchBonus");

                    b.Property<double>("StreetPrice");

                    b.Property<int>("SympathyBonus");

                    b.Property<int>("ThreatBonus");

                    b.HasKey("GearId");

                    b.HasAnnotation("Relational:TableName", "Gears");
                });

            modelBuilder.Entity("Spange.Models.PitchCamp", b =>
                {
                    b.Property<int>("PitchCampId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CampId");

                    b.Property<int>("PlayerId");

                    b.HasKey("PitchCampId");

                    b.HasAnnotation("Relational:TableName", "PitchCamps");
                });

            modelBuilder.Entity("Spange.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Appeal");

                    b.Property<int>("CurrentHp");

                    b.Property<string>("ImgLink");

                    b.Property<int>("MaxHp");

                    b.Property<string>("Name");

                    b.Property<int>("Satiation");

                    b.Property<int>("Sleep");

                    b.Property<double>("Spange");

                    b.Property<string>("UserId");

                    b.HasKey("PlayerId");

                    b.HasAnnotation("Relational:TableName", "Players");
                });

            modelBuilder.Entity("Spange.Models.PlayerFood", b =>
                {
                    b.Property<int>("PlayerFoodId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FoodId");

                    b.Property<int>("PlayerId");

                    b.HasKey("PlayerFoodId");

                    b.HasAnnotation("Relational:TableName", "PlayerFoods");
                });

            modelBuilder.Entity("Spange.Models.Spot", b =>
                {
                    b.Property<int>("SpotId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClaimSpotId");

                    b.Property<string>("Description");

                    b.Property<string>("ImgLink");

                    b.Property<string>("Location");

                    b.Property<int>("Pockets");

                    b.Property<int>("SpangeyPockets");

                    b.HasKey("SpotId");

                    b.HasAnnotation("Relational:TableName", "Spots");
                });

            modelBuilder.Entity("Spange.Models.ClaimSpot", b =>
                {
                    b.HasOne("Spange.Models.Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Spange.Models.Drug", b =>
                {
                    b.HasOne("Spange.Models.Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Spange.Models.PitchCamp", b =>
                {
                    b.HasOne("Spange.Models.Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Spange.Models.PlayerFood", b =>
                {
                    b.HasOne("Spange.Models.Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });
        }
    }
}
