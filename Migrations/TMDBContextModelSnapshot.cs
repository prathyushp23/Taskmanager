// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager.Models;

#nullable disable

namespace TaskManager.Migrations
{
    [DbContext(typeof(TMDBContext))]
    partial class TMDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaskManager.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"), 1L, 1);

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("TaskManager.Models.EmpTask", b =>
                {
                    b.Property<int>("TskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TskId"), 1L, 1);

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<string>("TskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TskId");

                    b.HasIndex("EmpId");

                    b.ToTable("EmpTask");
                });

            modelBuilder.Entity("TaskManager.Models.EmpTask", b =>
                {
                    b.HasOne("TaskManager.Models.Employee", "Employee")
                        .WithMany("EmpTasks")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TaskManager.Models.Employee", b =>
                {
                    b.Navigation("EmpTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
