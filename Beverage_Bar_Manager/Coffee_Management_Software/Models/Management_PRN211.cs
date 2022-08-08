using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Coffee_Management_Software.Models
{
    public partial class Management_PRN211 : DbContext
    {
        public Management_PRN211()
        {
        }

        public Management_PRN211(DbContextOptions<Management_PRN211> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<FoodCategory> FoodCategories { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<TableOr> TableOrs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //                optionsBuilder.UseSqlServer("server =(local); database = PRN211_GruopProject_CoffeeManagementSystem;uid=sa;pwd=123;");
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("PRN211DB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Account");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Employee");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Attendance1St)
                    .HasColumnName("Attendance1ST")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Attendance2Nd)
                    .HasColumnName("Attendance2ND")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AttendanceDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_Attendance_Employee");

                //entity.HasOne(d => d.IdShiftNavigation)
                //    .WithMany(p => p.Attendances)
                //    .HasForeignKey(d => d.IdShift)
                //    .HasConstraintName("FK_Attendance_Shift");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCheckIn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateCheckOut).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_Bill_Employee");

                entity.HasOne(d => d.IdTableNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdTable)
                    .HasConstraintName("FK_Bill_TableOr");
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasKey(e => new { e.IdBill, e.IdFood });

                entity.ToTable("BillDetail");

                entity.Property(e => e.Quality).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdBillNavigation)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.IdBill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BillDetail_Bill");

                entity.HasOne(d => d.IdFoodNavigation)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.IdFood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BillDetail_Food");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cmt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CMT");

                entity.Property(e => e.DateJoin).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo).IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.IdShiftNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdShift)
                    .HasConstraintName("FK_Employee_Shift");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Picture).HasMaxLength(1000);

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Size).HasMaxLength(5);

                entity.HasOne(d => d.IdCatagoryNavigation)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.IdCatagory)
                    .HasConstraintName("FK_Food_FoodCatagory");
            });

            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.ToTable("FoodCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<TableOr>(entity =>
            {
                entity.ToTable("TableOr");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Trống')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
