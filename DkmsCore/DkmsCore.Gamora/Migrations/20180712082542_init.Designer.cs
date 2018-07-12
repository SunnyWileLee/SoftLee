﻿// <auto-generated />
using DkmsCore.Gamora.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DkmsCore.Gamora.Migrations
{
    [DbContext(typeof(GamoraDbContext))]
    [Migration("20180712082542_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DkmsCore.Gamora.Entities.DkmsApiEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Service")
                        .HasMaxLength(200);

                    b.Property<Guid>("SiteId");

                    b.HasKey("Id");

                    b.ToTable("DkmsApi");
                });

            modelBuilder.Entity("DkmsCore.Gamora.Entities.DkmsSiteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("DocUrl")
                        .HasMaxLength(500);

                    b.Property<string>("Host")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("DkmsSite");
                });
#pragma warning restore 612, 618
        }
    }
}
