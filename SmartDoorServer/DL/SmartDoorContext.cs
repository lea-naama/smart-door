<<<<<<< HEAD
﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartDoorServer.Entities;

#nullable disable

namespace SmartDoorServer.DL
{
    public partial class SmartDoorContext : DbContext
    {
        public SmartDoorContext()
        {
        }

        public SmartDoorContext(DbContextOptions<SmartDoorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entities.Action> Actions { get; set; }
        public virtual DbSet<ActionType> ActionTypes { get; set; }
        public virtual DbSet<ApprovalType> ApprovalTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        public virtual DbSet<EnteringType> EnteringTypes { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<UserCase> UserCases { get; set; }
        public virtual DbSet<UserCaseProflie> UserCaseProflies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-N50PQOJ;Database=SmartDoor;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Entities.Action>(entity =>
            {
                entity.ToTable("ACTION");

                entity.Property(e => e.ActionId).HasColumnName("ACTION_ID");

                entity.Property(e => e.ActionTypeId).HasColumnName("ACTION_TYPE_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.EnteringTypeId).HasColumnName("ENTERING_TYPE_ID");

                entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");

                entity.HasOne(d => d.ActionType)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.ActionTypeId)
                    .HasConstraintName("FK_ACTION_ACTION_TYPE");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_ACTION_EMPLOYEE1");

                entity.HasOne(d => d.EnteringType)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.EnteringTypeId)
                    .HasConstraintName("FK_ACTION_ENTERING_TYPE");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_ACTION_STATUS");
            });

            modelBuilder.Entity<ActionType>(entity =>
            {
                entity.ToTable("ACTION_TYPE");

                entity.Property(e => e.ActionTypeId).HasColumnName("ACTION_TYPE_ID");

                entity.Property(e => e.ActionType1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACTION_TYPE");

                entity.Property(e => e.ApprovalTypeId).HasColumnName("APPROVAL_TYPE_ID");

                entity.Property(e => e.IsPresent).HasColumnName("IS_PRESENT");

                entity.HasOne(d => d.ApprovalType)
                    .WithMany(p => p.ActionTypes)
                    .HasForeignKey(d => d.ApprovalTypeId)
                    .HasConstraintName("FK_ACTION_TYPE_APPROVAL_TYPE");
            });

            modelBuilder.Entity<ApprovalType>(entity =>
            {
                entity.ToTable("APPROVAL_TYPE");

                entity.Property(e => e.ApprovalTypeId).HasColumnName("APPROVAL_TYPE_ID");

                entity.Property(e => e.ApprovalType1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL_TYPE");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ManagerId).HasColumnName("MANAGER_ID");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.DirectManagerId).HasColumnName("DIRECT_MANAGER_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.StandardDailyHours).HasColumnName("STANDARD_DAILY_HOURS");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_EMPLOYEE_DEPARTMENT");

                entity.HasOne(d => d.DirectManager)
                    .WithMany(p => p.InverseDirectManager)
                    .HasForeignKey(d => d.DirectManagerId)
                    .HasConstraintName("FK_EMPLOYEE_EMPLOYEE1");
            });

            modelBuilder.Entity<EmployeeProfile>(entity =>
            {
                entity.ToTable("EMPLOYEE_PROFILE");

                entity.Property(e => e.EmployeeProfileId).HasColumnName("EMPLOYEE_PROFILE_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.ProfileId).HasColumnName("PROFILE_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeProfiles)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EMPLOYEE_PROFILE_EMPLOYEE");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.EmployeeProfiles)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_EMPLOYEE_PROFILE_PROFILE");
            });

            modelBuilder.Entity<EnteringType>(entity =>
            {
                entity.ToTable("ENTERING_TYPE");

                entity.Property(e => e.EnteringTypeId).HasColumnName("ENTERING_TYPE_ID");

                entity.Property(e => e.EntringType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTRING_TYPE");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("PROFILE");

                entity.Property(e => e.ProfileId).HasColumnName("PROFILE_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("STATUS");

                entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");

                entity.Property(e => e.Status1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<UserCase>(entity =>
            {
                entity.ToTable("USER_CASE");

                entity.Property(e => e.UserCaseId).HasColumnName("USER_CASE_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<UserCaseProflie>(entity =>
            {
                entity.HasKey(e => e.UserCaseProfileId);

                entity.ToTable("USER_CASE_PROFLIE");

                entity.Property(e => e.UserCaseProfileId).HasColumnName("USER_CASE_PROFILE_ID");

                entity.Property(e => e.ProfileId).HasColumnName("PROFILE_ID");

                entity.Property(e => e.UserCaseId).HasColumnName("USER_CASE_ID");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.UserCaseProflies)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_USER_CASE_PROFLIE_PROFILE");

                entity.HasOne(d => d.UserCase)
                    .WithMany(p => p.UserCaseProflies)
                    .HasForeignKey(d => d.UserCaseId)
                    .HasConstraintName("FK_USER_CASE_PROFLIE_USER_CASE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
=======
﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartDoorServer.Entities;
using Action = SmartDoorServer.Entities.Action;

#nullable disable

namespace DL
{
    public partial class SmartDoorContext : DbContext
    {
        public SmartDoorContext()
        {
        }

        public SmartDoorContext(DbContextOptions<SmartDoorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ActionType> ActionTypes { get; set; }
        public virtual DbSet<ApprovalType> ApprovalTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        public virtual DbSet<EnteringType> EnteringTypes { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<UserCase> UserCases { get; set; }
        public virtual DbSet<UserCaseProflie> UserCaseProflies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TTNF4F0\\MSSQLSERVER2;Database=SmartDoor;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("ACTION");

                entity.Property(e => e.ActionId).HasColumnName("ACTION_ID");

                entity.Property(e => e.ActionTypeId).HasColumnName("ACTION_TYPE_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.EnteringTypeId).HasColumnName("ENTERING_TYPE_ID");

                entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");

                entity.HasOne(d => d.ActionType)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.ActionTypeId)
                    .HasConstraintName("FK_ACTION_ACTION_TYPE");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_ACTION_EMPLOYEE1");

                entity.HasOne(d => d.EnteringType)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.EnteringTypeId)
                    .HasConstraintName("FK_ACTION_ENTERING_TYPE");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_ACTION_STATUS");
            });

            modelBuilder.Entity<ActionType>(entity =>
            {
                entity.ToTable("ACTION_TYPE");

                entity.Property(e => e.ActionTypeId).HasColumnName("ACTION_TYPE_ID");

                entity.Property(e => e.ActionType1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACTION_TYPE");

                entity.Property(e => e.ApprovalTypeId).HasColumnName("APPROVAL_TYPE_ID");

                entity.Property(e => e.IsPresent).HasColumnName("IS_PRESENT");

                entity.HasOne(d => d.ApprovalType)
                    .WithMany(p => p.ActionTypes)
                    .HasForeignKey(d => d.ApprovalTypeId)
                    .HasConstraintName("FK_ACTION_TYPE_APPROVAL_TYPE");
            });

            modelBuilder.Entity<ApprovalType>(entity =>
            {
                entity.ToTable("APPROVAL_TYPE");

                entity.Property(e => e.ApprovalTypeId).HasColumnName("APPROVAL_TYPE_ID");

                entity.Property(e => e.ApprovalType1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL_TYPE");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ManagerId).HasColumnName("MANAGER_ID");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.DirectManagerId).HasColumnName("DIRECT_MANAGER_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.StandardDailyHours).HasColumnName("STANDARD_DAILY_HOURS");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_EMPLOYEE_DEPARTMENT");

                entity.HasOne(d => d.DirectManager)
                    .WithMany(p => p.InverseDirectManager)
                    .HasForeignKey(d => d.DirectManagerId)
                    .HasConstraintName("FK_EMPLOYEE_EMPLOYEE1");
            });

            modelBuilder.Entity<EmployeeProfile>(entity =>
            {
                entity.ToTable("EMPLOYEE_PROFILE");

                entity.Property(e => e.EmployeeProfileId).HasColumnName("EMPLOYEE_PROFILE_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.ProfileId).HasColumnName("PROFILE_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeProfiles)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EMPLOYEE_PROFILE_EMPLOYEE");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.EmployeeProfiles)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_EMPLOYEE_PROFILE_PROFILE");
            });

            modelBuilder.Entity<EnteringType>(entity =>
            {
                entity.ToTable("ENTERING_TYPE");

                entity.Property(e => e.EnteringTypeId).HasColumnName("ENTERING_TYPE_ID");

                entity.Property(e => e.EntringType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTRING_TYPE");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("PROFILE");

                entity.Property(e => e.ProfileId).HasColumnName("PROFILE_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("STATUS");

                entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");

                entity.Property(e => e.Status1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<UserCase>(entity =>
            {
                entity.ToTable("USER_CASE");

                entity.Property(e => e.UserCaseId).HasColumnName("USER_CASE_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<UserCaseProflie>(entity =>
            {
                entity.HasKey(e => e.UserCaseProfileId);

                entity.ToTable("USER_CASE_PROFLIE");

                entity.Property(e => e.UserCaseProfileId).HasColumnName("USER_CASE_PROFILE_ID");

                entity.Property(e => e.ProfileId).HasColumnName("PROFILE_ID");

                entity.Property(e => e.UserCaseId).HasColumnName("USER_CASE_ID");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.UserCaseProflies)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_USER_CASE_PROFLIE_PROFILE");

                entity.HasOne(d => d.UserCase)
                    .WithMany(p => p.UserCaseProflies)
                    .HasForeignKey(d => d.UserCaseId)
                    .HasConstraintName("FK_USER_CASE_PROFLIE_USER_CASE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
>>>>>>> 3fe4ef61862493bdcb29b21f9204f9c668744064
