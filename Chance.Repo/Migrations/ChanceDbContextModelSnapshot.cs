﻿// <auto-generated />
using Chance.Repo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chance.Repo.Migrations
{
    [DbContext(typeof(ChanceDbContext))]
    partial class ChanceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AbilityCharacter", b =>
                {
                    b.Property<int>("AbilitiesAbilityType")
                        .HasColumnType("int");

                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.HasKey("AbilitiesAbilityType", "CharactersId");

                    b.HasIndex("CharactersId");

                    b.ToTable("AbilityCharacter");
                });

            modelBuilder.Entity("AbilityClass", b =>
                {
                    b.Property<int>("AbilitiesAbilityType")
                        .HasColumnType("int");

                    b.Property<int>("ClassesId")
                        .HasColumnType("int");

                    b.HasKey("AbilitiesAbilityType", "ClassesId");

                    b.HasIndex("ClassesId");

                    b.ToTable("AbilityClass");
                });

            modelBuilder.Entity("BackgroundSkill", b =>
                {
                    b.Property<int>("BackgroundsId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsSkillType")
                        .HasColumnType("int");

                    b.HasKey("BackgroundsId", "SkillsSkillType");

                    b.HasIndex("SkillsSkillType");

                    b.ToTable("BackgroundSkill");
                });

            modelBuilder.Entity("Chance.Repo.Models.Ability", b =>
                {
                    b.Property<int>("AbilityType")
                        .HasColumnType("int");

                    b.HasKey("AbilityType");

                    b.ToTable("Abilities");

                    b.HasData(
                        new
                        {
                            AbilityType = 0
                        },
                        new
                        {
                            AbilityType = 1
                        },
                        new
                        {
                            AbilityType = 2
                        },
                        new
                        {
                            AbilityType = 3
                        },
                        new
                        {
                            AbilityType = 4
                        },
                        new
                        {
                            AbilityType = 5
                        });
                });

            modelBuilder.Entity("Chance.Repo.Models.Background", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Backgrounds");
                });

            modelBuilder.Entity("Chance.Repo.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Alignment")
                        .HasColumnType("int");

                    b.Property<int>("BackgroundId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("SubraceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("XP")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BackgroundId");

                    b.HasIndex("ClassId");

                    b.HasIndex("RaceId");

                    b.HasIndex("SubraceId");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Chance.Repo.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SkillProficiencyCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Chance.Repo.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Chance.Repo.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IncreaseAbilityId")
                        .HasColumnType("int");

                    b.Property<int>("IncreaseAbilityScore")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IncreaseAbilityId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Chance.Repo.Models.Skill", b =>
                {
                    b.Property<int>("SkillType")
                        .HasColumnType("int");

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.HasKey("SkillType");

                    b.HasIndex("AbilityId");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            SkillType = 0,
                            AbilityId = 1
                        },
                        new
                        {
                            SkillType = 1,
                            AbilityId = 4
                        },
                        new
                        {
                            SkillType = 2,
                            AbilityId = 3
                        },
                        new
                        {
                            SkillType = 3,
                            AbilityId = 0
                        },
                        new
                        {
                            SkillType = 4,
                            AbilityId = 5
                        },
                        new
                        {
                            SkillType = 5,
                            AbilityId = 3
                        },
                        new
                        {
                            SkillType = 6,
                            AbilityId = 4
                        },
                        new
                        {
                            SkillType = 7,
                            AbilityId = 5
                        },
                        new
                        {
                            SkillType = 8,
                            AbilityId = 3
                        },
                        new
                        {
                            SkillType = 9,
                            AbilityId = 4
                        },
                        new
                        {
                            SkillType = 10,
                            AbilityId = 3
                        },
                        new
                        {
                            SkillType = 11,
                            AbilityId = 4
                        },
                        new
                        {
                            SkillType = 12,
                            AbilityId = 5
                        },
                        new
                        {
                            SkillType = 13,
                            AbilityId = 5
                        },
                        new
                        {
                            SkillType = 14,
                            AbilityId = 3
                        },
                        new
                        {
                            SkillType = 15,
                            AbilityId = 1
                        },
                        new
                        {
                            SkillType = 16,
                            AbilityId = 1
                        },
                        new
                        {
                            SkillType = 17,
                            AbilityId = 4
                        });
                });

            modelBuilder.Entity("Chance.Repo.Models.Subrace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IncreaseAbilityId")
                        .HasColumnType("int");

                    b.Property<int>("IncreaseAbilityScore")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IncreaseAbilityId");

                    b.HasIndex("RaceId");

                    b.ToTable("Subraces");
                });

            modelBuilder.Entity("Chance.Repo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClassFeature", b =>
                {
                    b.Property<int>("ClassesId")
                        .HasColumnType("int");

                    b.Property<int>("FeaturesId")
                        .HasColumnType("int");

                    b.HasKey("ClassesId", "FeaturesId");

                    b.HasIndex("FeaturesId");

                    b.ToTable("ClassFeature");
                });

            modelBuilder.Entity("ClassSkill", b =>
                {
                    b.Property<int>("ClassesId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsSkillType")
                        .HasColumnType("int");

                    b.HasKey("ClassesId", "SkillsSkillType");

                    b.HasIndex("SkillsSkillType");

                    b.ToTable("ClassSkill");
                });

            modelBuilder.Entity("FeatureRace", b =>
                {
                    b.Property<int>("FeaturesId")
                        .HasColumnType("int");

                    b.Property<int>("RacesId")
                        .HasColumnType("int");

                    b.HasKey("FeaturesId", "RacesId");

                    b.HasIndex("RacesId");

                    b.ToTable("FeatureRace");
                });

            modelBuilder.Entity("FeatureSubrace", b =>
                {
                    b.Property<int>("FeaturesId")
                        .HasColumnType("int");

                    b.Property<int>("SubracesId")
                        .HasColumnType("int");

                    b.HasKey("FeaturesId", "SubracesId");

                    b.HasIndex("SubracesId");

                    b.ToTable("FeatureSubrace");
                });

            modelBuilder.Entity("AbilityCharacter", b =>
                {
                    b.HasOne("Chance.Repo.Models.Ability", null)
                        .WithMany()
                        .HasForeignKey("AbilitiesAbilityType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("AbilityClass", b =>
                {
                    b.HasOne("Chance.Repo.Models.Ability", null)
                        .WithMany()
                        .HasForeignKey("AbilitiesAbilityType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("BackgroundSkill", b =>
                {
                    b.HasOne("Chance.Repo.Models.Background", null)
                        .WithMany()
                        .HasForeignKey("BackgroundsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsSkillType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Chance.Repo.Models.Character", b =>
                {
                    b.HasOne("Chance.Repo.Models.Background", "Background")
                        .WithMany("Characters")
                        .HasForeignKey("BackgroundId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.Class", "Class")
                        .WithMany("Characters")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.Race", "Race")
                        .WithMany("Characters")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.Subrace", "Subrace")
                        .WithMany("Characters")
                        .HasForeignKey("SubraceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Background");

                    b.Navigation("Class");

                    b.Navigation("Race");

                    b.Navigation("Subrace");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Chance.Repo.Models.Race", b =>
                {
                    b.HasOne("Chance.Repo.Models.Ability", "IncreaseAbility")
                        .WithMany("Races")
                        .HasForeignKey("IncreaseAbilityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("IncreaseAbility");
                });

            modelBuilder.Entity("Chance.Repo.Models.Skill", b =>
                {
                    b.HasOne("Chance.Repo.Models.Ability", "Ability")
                        .WithMany("Skills")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ability");
                });

            modelBuilder.Entity("Chance.Repo.Models.Subrace", b =>
                {
                    b.HasOne("Chance.Repo.Models.Ability", "IncreaseAbility")
                        .WithMany("Subraces")
                        .HasForeignKey("IncreaseAbilityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.Race", "Race")
                        .WithMany("Subraces")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("IncreaseAbility");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("ClassFeature", b =>
                {
                    b.HasOne("Chance.Repo.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassSkill", b =>
                {
                    b.HasOne("Chance.Repo.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsSkillType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FeatureRace", b =>
                {
                    b.HasOne("Chance.Repo.Models.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.Race", null)
                        .WithMany()
                        .HasForeignKey("RacesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FeatureSubrace", b =>
                {
                    b.HasOne("Chance.Repo.Models.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chance.Repo.Models.Subrace", null)
                        .WithMany()
                        .HasForeignKey("SubracesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Chance.Repo.Models.Ability", b =>
                {
                    b.Navigation("Races");

                    b.Navigation("Skills");

                    b.Navigation("Subraces");
                });

            modelBuilder.Entity("Chance.Repo.Models.Background", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Chance.Repo.Models.Class", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Chance.Repo.Models.Race", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Subraces");
                });

            modelBuilder.Entity("Chance.Repo.Models.Subrace", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Chance.Repo.Models.User", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
