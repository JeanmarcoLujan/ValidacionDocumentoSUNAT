// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SUNATValidation.Context;

#nullable disable

namespace SUNATValidation.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SUNATValidation.Models.Purcharse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("DocRate")
                        .HasColumnType("float");

                    b.Property<double>("DocTotal")
                        .HasColumnType("float");

                    b.Property<string>("FechaComp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumComp")
                        .HasColumnType("int");

                    b.Property<string>("NumDocSN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumRegistro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerieComp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoComp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoDocSN")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Purcharses");
                });

            modelBuilder.Entity("SUNATValidation.Models.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DateRate")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Purchase")
                        .HasColumnType("float");

                    b.Property<double>("Sale")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DateRate")
                        .IsUnique();

                    b.ToTable("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}
