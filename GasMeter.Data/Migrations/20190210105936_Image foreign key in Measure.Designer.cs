﻿// <auto-generated />
using System;
using GasMeter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GasMeter.Data.Migrations
{
    [DbContext(typeof(GasMeterDbContext))]
    [Migration("20190210105936_Image foreign key in Measure")]
    partial class ImageforeignkeyinMeasure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GasMeter.DataModels.CapturedImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Data");

                    b.Property<DateTime>("DateTaken");

                    b.HasKey("Id");

                    b.ToTable("CapturedImages");
                });

            modelBuilder.Entity("GasMeter.DataModels.Measure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<Guid>("ImageId");

                    b.Property<double>("Measurement");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Measures");
                });

            modelBuilder.Entity("GasMeter.DataModels.Measure", b =>
                {
                    b.HasOne("GasMeter.DataModels.CapturedImage", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
