using LWAJWTLOG.Models;
using Microsoft.EntityFrameworkCore;



namespace LWAJWTLOG.Model
{
    
    

        public partial class DatabaseContext : DbContext
        {
            public DatabaseContext()
            {
            }

            public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
            {
            }

            public virtual DbSet<UserRegistration>? UserRegistrations  { get; set; }
            public virtual DbSet<UserInfo>? UserInfos { get; set; }
            public virtual DbSet<Student>? Student { get; set; }
            public virtual DbSet<StudentCourse>? StudentCourse { get; set; }
            public object UserRegistration { get; internal set; }
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<UserInfo>(entity =>
                {
                    entity.HasNoKey();
                    entity.ToTable("UserInfo");
                    entity.Property(e => e.UserId).HasColumnName("UserId");
                    entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                    entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                    entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                    entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                    entity.Property(e => e.CreatedDate).IsUnicode(false);
                });

                modelBuilder.Entity<UserRegistration>(entity =>
                {
                    entity.ToTable("UserRegistration");
                    entity.Property(e => e.id).HasColumnName("id");
                    entity.Property(e => e.Name).HasMaxLength(15).IsUnicode(false);
                    entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
                    entity.Property(e => e.Username).HasMaxLength(256).IsUnicode(false);
                    entity.Property(e => e.password).HasMaxLength(50).IsUnicode(false);
                    entity.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false);
                    
                });
            modelBuilder.Entity<Student>(entity =>
            {
               
                entity.ToTable("Student");
                entity.HasKey(e => e.Rollno);
                entity.Property(e => e.Rollno).HasColumnName("RollNo");
                entity.Property(e => e.Name).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.Phoneno).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Address).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.City).HasMaxLength(20).IsUnicode(false);


            });
            modelBuilder.Entity<StudentCourse>(entity =>
            {

                entity.ToTable("StudentCourse");
                entity.HasKey(e => e.Courseid);
                entity.Property(e => e.StudentName).HasColumnName("StudentName");
                entity.Property(e => e.CourseName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.Courseid).HasMaxLength(30).IsUnicode(false);
               


            });
           



            OnModelCreatingPartial(modelBuilder);
            }

            partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        }
    }

