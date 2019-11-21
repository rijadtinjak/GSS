﻿// <auto-generated />
using System;
using GSS.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GSS.Database.Migrations
{
    [DbContext(typeof(GSSContext))]
    [Migration("20191119230733_tables")]
    partial class tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GSS.Database.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("GSS.Database.Consensus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManagerId");

                    b.Property<double>("Value");

                    b.Property<int>("ZoneId");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Consensus");
                });

            modelBuilder.Entity("GSS.Database.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("GSS.Database.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("SearchId");

                    b.HasKey("Id");

                    b.HasIndex("SearchId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("GSS.Database.Search", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateClosed");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Searches");
                });

            modelBuilder.Entity("GSS.Database.Segment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Area");

                    b.Property<string>("Name");

                    b.Property<int?>("ZoneId");

                    b.HasKey("Id");

                    b.HasIndex("ZoneId");

                    b.ToTable("Segments");
                });

            modelBuilder.Entity("GSS.Database.SegmentSearchHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Coverage");

                    b.Property<double>("DeltaPoS");

                    b.Property<int>("NoOfSearchers");

                    b.Property<double>("Pden");

                    b.Property<double>("PoA");

                    b.Property<double>("PoD");

                    b.Property<double>("PoDCumulative");

                    b.Property<double>("PoS");

                    b.Property<double>("PoSCumulative");

                    b.Property<int>("SegmentId");

                    b.Property<double>("SweepWidth");

                    b.Property<double>("TrackLength");

                    b.Property<int>("TypeOfSearcher");

                    b.HasKey("Id");

                    b.HasIndex("SegmentId");

                    b.ToTable("SegmentSearchHistory");
                });

            modelBuilder.Entity("GSS.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("CityId");

                    b.Property<string>("Email");

                    b.Property<string>("OrganizationName");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GSS.Database.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Area");

                    b.Property<string>("Name");

                    b.Property<double>("Pden");

                    b.Property<double>("PoA");

                    b.Property<int>("SearchId");

                    b.HasKey("Id");

                    b.HasIndex("SearchId");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("GSS.Database.City", b =>
                {
                    b.HasOne("GSS.Database.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GSS.Database.Consensus", b =>
                {
                    b.HasOne("GSS.Database.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GSS.Database.Zone", "Zone")
                        .WithMany("Consensus")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GSS.Database.Manager", b =>
                {
                    b.HasOne("GSS.Database.Search", "Search")
                        .WithMany("Managers")
                        .HasForeignKey("SearchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GSS.Database.Search", b =>
                {
                    b.HasOne("GSS.Database.User", "User")
                        .WithMany("Searches")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GSS.Database.Segment", b =>
                {
                    b.HasOne("GSS.Database.Zone", "Zone")
                        .WithMany("Segments")
                        .HasForeignKey("ZoneId");
                });

            modelBuilder.Entity("GSS.Database.SegmentSearchHistory", b =>
                {
                    b.HasOne("GSS.Database.Segment", "Segment")
                        .WithMany("SegmentHistory")
                        .HasForeignKey("SegmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GSS.Database.User", b =>
                {
                    b.HasOne("GSS.Database.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GSS.Database.Zone", b =>
                {
                    b.HasOne("GSS.Database.Search", "Search")
                        .WithMany("Zones")
                        .HasForeignKey("SearchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
