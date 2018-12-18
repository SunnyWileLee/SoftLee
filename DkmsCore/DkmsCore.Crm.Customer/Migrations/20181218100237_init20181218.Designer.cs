﻿// <auto-generated />
using System;
using DkmsCore.Crm.Customer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DkmsCore.Crm.Customer.Migrations
{
    [DbContext(typeof(CrmCustomerDbContext))]
    [Migration("20181218100237_init20181218")]
    partial class init20181218
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DkmsCore.Crm.Customer.Repositories.CustomerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<int>("State");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DkmsCore.Crm.Customer.Repositories.CustomerPropertyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("CustomerProperty");
                });

            modelBuilder.Entity("DkmsCore.Crm.Customer.Repositories.CustomerPropertyValueEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<Guid>("InstanceId")
                        .HasColumnName("CustomerId");

                    b.Property<Guid>("PropertyId");

                    b.Property<Guid>("UserId");

                    b.Property<string>("Value")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("CustomerPropertyValue");
                });
#pragma warning restore 612, 618
        }
    }
}
