using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MoneyMaker.Data;

namespace MoneyMaker.Migrations
{
    [DbContext(typeof(MoneyMakerContext))]
    [Migration("20161113173053_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoneyMaker.Models.NflWeek", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End");

                    b.Property<DateTime>("Start");

                    b.HasKey("ID");

                    b.ToTable("NflWeeks");
                });
        }
    }
}
