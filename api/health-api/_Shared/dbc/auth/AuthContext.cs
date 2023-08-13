using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace health_api._Shared.dbc.auth;

public partial class AuthContext : DbContext
{
    public AuthContext()
    {
    }

    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    public virtual DbSet<License> Licenses { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLicense> UserLicenses { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<License>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("license_pkey");

            entity.ToTable("license", "auth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableAppointment)
                .HasColumnType("character varying")
                .HasColumnName("available_appointment");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Hid)
                .HasColumnType("character varying")
                .HasColumnName("hid");
            entity.Property(e => e.Ractive)
                .HasDefaultValueSql("true")
                .HasColumnName("ractive");
            entity.Property(e => e.Rcb)
                .HasDefaultValueSql("1")
                .HasColumnName("rcb");
            entity.Property(e => e.Rct).HasColumnName("rct");
            entity.Property(e => e.Rdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("rdeleted");
            entity.Property(e => e.Rub).HasColumnName("rub");
            entity.Property(e => e.Rut).HasColumnName("rut");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("project_pkey");

            entity.ToTable("project", "auth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abbrv)
                .HasColumnType("character varying")
                .HasColumnName("abbrv");
            entity.Property(e => e.BaseUrl)
                .HasColumnType("character varying")
                .HasColumnName("base_url");
            entity.Property(e => e.Config).HasColumnName("config");
            entity.Property(e => e.DisplayTitle)
                .HasColumnType("character varying")
                .HasColumnName("display_title");
            entity.Property(e => e.Hid)
                .HasMaxLength(8)
                .HasColumnName("hid");
            entity.Property(e => e.IsStartupProject)
                .HasDefaultValueSql("false")
                .HasColumnName("is_startup_project");
            entity.Property(e => e.LogoPath)
                .HasColumnType("character varying")
                .HasColumnName("logo_path");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Ractive)
                .HasDefaultValueSql("true")
                .HasColumnName("ractive");
            entity.Property(e => e.Rcb).HasColumnName("rcb");
            entity.Property(e => e.Rct).HasColumnName("rct");
            entity.Property(e => e.Rdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("rdeleted");
            entity.Property(e => e.Rub).HasColumnName("rub");
            entity.Property(e => e.Rut).HasColumnName("rut");
            entity.Property(e => e.Theme)
                .HasColumnType("character varying")
                .HasColumnName("theme");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role", "auth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Hid)
                .HasColumnType("character varying")
                .HasColumnName("hid");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Ractive)
                .HasDefaultValueSql("true")
                .HasColumnName("ractive");
            entity.Property(e => e.Rcb)
                .HasDefaultValueSql("1")
                .HasColumnName("rcb");
            entity.Property(e => e.Rct)
                .HasDefaultValueSql("now()")
                .HasColumnName("rct");
            entity.Property(e => e.Rdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("rdeleted");
            entity.Property(e => e.Rub).HasColumnName("rub");
            entity.Property(e => e.Rut).HasColumnName("rut");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user", "auth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contact)
                .HasColumnType("character varying")
                .HasColumnName("contact");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FailedCount)
                .HasDefaultValueSql("0")
                .HasColumnName("failed_count");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.FullName)
                .HasColumnType("character varying")
                .HasColumnName("full_name");
            entity.Property(e => e.Hid)
                .HasColumnType("character varying")
                .HasColumnName("hid");
            entity.Property(e => e.IsLock)
                .HasDefaultValueSql("false")
                .HasColumnName("is_lock");
            entity.Property(e => e.IsLockedOut)
                .HasDefaultValueSql("false")
                .HasColumnName("is_locked_out");
            entity.Property(e => e.LastName)
                .HasColumnType("character varying")
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Ractive)
                .HasDefaultValueSql("true")
                .HasColumnName("ractive");
            entity.Property(e => e.Rcb)
                .HasDefaultValueSql("1")
                .HasColumnName("rcb");
            entity.Property(e => e.Rct)
                .HasDefaultValueSql("now()")
                .HasColumnName("rct");
            entity.Property(e => e.Rdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("rdeleted");
            entity.Property(e => e.Rub).HasColumnName("rub");
            entity.Property(e => e.Rut).HasColumnName("rut");
        });

        modelBuilder.Entity<UserLicense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_license_pkey");

            entity.ToTable("user_license", "auth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Hid)
                .HasColumnType("character varying")
                .HasColumnName("hid");
            entity.Property(e => e.LicenseId).HasColumnName("license_id");
            entity.Property(e => e.Ractive)
                .HasDefaultValueSql("true")
                .HasColumnName("ractive");
            entity.Property(e => e.Rcb)
                .HasDefaultValueSql("1")
                .HasColumnName("rcb");
            entity.Property(e => e.Rct).HasColumnName("rct");
            entity.Property(e => e.Rdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("rdeleted");
            entity.Property(e => e.Rub).HasColumnName("rub");
            entity.Property(e => e.Rut).HasColumnName("rut");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.License).WithMany(p => p.UserLicenses)
                .HasForeignKey(d => d.LicenseId)
                .HasConstraintName("fk_user_license_license");

            entity.HasOne(d => d.User).WithMany(p => p.UserLicenses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_license_user");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_role_pkey");

            entity.ToTable("user_role", "auth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Hid)
                .HasColumnType("character varying")
                .HasColumnName("hid");
            entity.Property(e => e.Ractive)
                .HasDefaultValueSql("true")
                .HasColumnName("ractive");
            entity.Property(e => e.Rcb)
                .HasDefaultValueSql("1")
                .HasColumnName("rcb");
            entity.Property(e => e.Rct)
                .HasDefaultValueSql("now()")
                .HasColumnName("rct");
            entity.Property(e => e.Rdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("rdeleted");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Rub).HasColumnName("rub");
            entity.Property(e => e.Rut).HasColumnName("rut");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_user_role_role");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_role_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
