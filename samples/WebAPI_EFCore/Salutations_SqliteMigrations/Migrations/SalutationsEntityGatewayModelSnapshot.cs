﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalutationPorts.EntityGateway;

namespace Salutations_SqliteMigrations.Migrations
{
    [DbContext(typeof(SalutationsEntityGateway))]
    partial class SalutationsEntityGatewayModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("SalutationEntities.Salutation", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Greeting")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("TimeStamp")
                        .HasColumnType("BLOB");

                    b.HasKey("_id");

                    b.ToTable("People");
                });
#pragma warning restore 612, 618
        }
    }
}
