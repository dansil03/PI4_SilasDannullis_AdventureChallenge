// <auto-generated />
using AdventureChallenge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdventureChallenge.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221003123446_Add_Data")]
    partial class Add_Data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AdventureChallenge.Models.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ChallengeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChallengeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPlayers")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("challenges");
                });

            modelBuilder.Entity("AdventureChallenge.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AdventureChallenge.Models.UserChallenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<string>("ProofText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("UserId");

                    b.ToTable("userChallenges");
                });

            modelBuilder.Entity("AdventureChallenge.Models.UserChallenge", b =>
                {
                    b.HasOne("AdventureChallenge.Models.Challenge", "Challenge")
                        .WithMany("User")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdventureChallenge.Models.User", "User")
                        .WithMany("UserChallenges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AdventureChallenge.Models.Challenge", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("AdventureChallenge.Models.User", b =>
                {
                    b.Navigation("UserChallenges");
                });
#pragma warning restore 612, 618
        }
    }
}
