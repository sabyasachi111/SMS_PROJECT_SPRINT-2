using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SMS_API.Data
{
    public partial class SMSContext : DbContext
    {
        public SMSContext()
        {
        }

        public SMSContext(DbContextOptions<SMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Cashier> Cashiers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SMSdb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("ADMIN");

                entity.Property(e => e.AdminId)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("ADMIN_ID");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_NAME");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("ATTENDANCE");

                entity.Property(e => e.AttendanceId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("ATTENDANCE_ID");

                entity.Property(e => e.AttendanceDate)
                    .HasColumnType("date")
                    .HasColumnName("ATTENDANCE_DATE");

                entity.Property(e => e.Attended)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ATTENDED")
                    .IsFixedLength(true);

                entity.Property(e => e.StudentId)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("STUDENT_ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("AT_FK");
            });

            modelBuilder.Entity<Cashier>(entity =>
            {
                entity.ToTable("CASHIER");

                entity.Property(e => e.CashierId)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("CASHIER_ID");

                entity.Property(e => e.CashierName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CASHIER_NAME");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.ClassName)
                    .HasName("CL_PK");

                entity.ToTable("CLASS");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CLASS_NAME");
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("FE_PK");

                entity.ToTable("FEES");

                entity.Property(e => e.InvoiceId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("INVOICE_ID");

                entity.Property(e => e.CashierId)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("CASHIER_ID");

                entity.Property(e => e.FeesAmount)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("FEES_AMOUNT");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("PAYMENT_DATE");

                entity.Property(e => e.StudentId)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("STUDENT_ID");

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.CashierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FEE_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FE_FK");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("GRADE");

                entity.Property(e => e.GradeId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("GRADE_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.GradeName)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GRADE_NAME");

                entity.Property(e => e.StudentId)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("STUDENT_ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("GD_FK");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.LoginId)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Role)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ROLE");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.StudentId)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("STUDENT_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.BloodGroup)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("BLOOD_GROUP");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CLASS_NAME");

                entity.Property(e => e.Contact)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("CONTACT");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("STUDENT_NAME");

                entity.HasOne(d => d.ClassNameNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassName)
                    .HasConstraintName("ST_FK");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("TEACHER");

                entity.Property(e => e.TeacherId)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("TEACHER_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CLASS_NAME");

                entity.Property(e => e.Contact)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("CONTACT");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.TeacherName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TEACHER_NAME");

                entity.HasOne(d => d.ClassNameNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.ClassName)
                    .HasConstraintName("TE_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
