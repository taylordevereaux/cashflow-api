using System;
using CashFlow.Api.Repository.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CashFlow.Api.Repository
{
    public partial class CashFlowDbContext : IdentityDbContext<
            User,
            Role,
            Guid,
            IdentityUserClaim<Guid>,
            UserRole,
            IdentityUserLogin<Guid>,
            IdentityRoleClaim<Guid>,
            IdentityUserToken<Guid>>
    {
        public CashFlowDbContext(DbContextOptions<CashFlowDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<RecurringTransaction> RecurringTransactions { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account", "CashFlow");

                entity.Property(e => e.AccountId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(20, 6)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(GetDate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartingAmount).HasColumnType("decimal(20, 6)");

                entity.HasOne(d => d.AccountType)
                    .WithMany()
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountType", "Lookup");

                entity.HasIndex(e => e.AccountTypeConstant)
                    .IsUnique();

                entity.Property(e => e.AccountTypeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountTypeConstant)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(GetDate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasData(
                    new AccountType()
                    {
                        AccountTypeId = Guid.Parse("B86863A3-DB66-46E7-87AF-BF2A49D66FF9"),
                        AccountTypeConstant = "CREDIT",
                        Name = "Credit"
                    },
                    new AccountType()
                    {
                        AccountTypeId = Guid.Parse("2920127B-999C-455E-8536-E65CEAB8552C"),
                        AccountTypeConstant = "CHEQUING",
                        Name = "Chequing"
                    },
                    new AccountType()
                    {
                        AccountTypeId = Guid.Parse("C83C4B41-21D2-461A-A85F-F930F65BA561"),
                        AccountTypeConstant = "SAVINGS",
                        Name = "Savings"
                    }
                );
            });

            modelBuilder.Entity<RecurringTransaction>(entity =>
            {
                entity.ToTable("RecurringTransaction", "CashFlow");

                entity.HasIndex(e => e.ScheduleId)
                    .IsUnique();

                entity.Property(e => e.RecurringTransactionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(20, 6)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(GetDate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RecurringTransactions)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Schedule)
                    .WithOne(p => p.RecurringTransaction)
                    .HasForeignKey<RecurringTransaction>(d => d.ScheduleId);

                entity.HasOne(d => d.TransactionType);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule", "CashFlow");

                entity.Property(e => e.ScheduleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(GetDate())");

                entity.Property(e => e.DayOfWeek)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Ordinal)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.RecurrenceAmount).HasDefaultValueSql("((1))");

                entity.Property(e => e.RecurrenceType)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction", "CashFlow");

                entity.Property(e => e.TransactionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(20, 6)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(GetDate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TransactionType);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("TransactionType", "Lookup");

                entity.HasIndex(e => e.TransactionTypeConstant)
                    .IsUnique();

                entity.Property(e => e.TransactionTypeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(GetDate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionTypeConstant)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasData(
                    new TransactionType()
                    {
                        TransactionTypeId = Guid.Parse("B47DEACE-4C2E-4F43-9125-8F78409ED8C2"),
                        TransactionTypeConstant = "INCOME",
                        Name = "Income"
                    },
                    new TransactionType()
                    {
                        TransactionTypeId = Guid.Parse("12A56DF0-D4DE-4462-885E-BCCE46DDA838"),
                        TransactionTypeConstant = "EXPENSE",
                        Name = "Expense"
                    }
                );
            });
        }
    }
}
