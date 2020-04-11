using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class epsContext : DbContext
    {
        public epsContext()
        {
        }

        public epsContext(DbContextOptions<epsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Diseases> Diseases { get; set; }
        public virtual DbSet<DiseasesList> DiseasesList { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Specializations> Specializations { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=YUXARM0007L\\SQLEXPRESS;database=Eps;user id=sa;password=Asdf1234$;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Observations).IsRequired();

                entity.Property(e => e.PatientDescription).IsRequired();

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Appointme__Docto__47DBAE45");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Appointme__Perso__46E78A0C");
            });

            modelBuilder.Entity<Diseases>(entity =>
            {
                entity.Property(e => e.DiseasesName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DiseasesList>(entity =>
            {
                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.DiseasesList)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__DiseasesL__Appoi__4CA06362");

                entity.HasOne(d => d.Disease)
                    .WithMany(p => p.DiseasesList)
                    .HasForeignKey(d => d.DiseaseId)
                    .HasConstraintName("FK__DiseasesL__Disea__4AB81AF0");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.DiseasesList)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__DiseasesL__Perso__4BAC3F29");
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Doctors__PersonI__412EB0B6");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__Doctors__Special__4222D4EF");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Specializations>(entity =>
            {
                entity.Property(e => e.SpecializationName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Users__PersonId__3B75D760");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__RoleId__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
