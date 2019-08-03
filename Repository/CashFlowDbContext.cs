using System;
using CashFlow.Api.Repository.Models;
using CashFlow.Repository.Models.Budget;
using CashFlow.Repository.Models.UBudget;
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
        const string AmountColumnType = "decimal(20, 6)";
        const string PercentageColumnType = "decimal(5, 4)";

        public CashFlowDbContext(DbContextOptions<CashFlowDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<RecurringTransaction> RecurringTransactions { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }

        // Budgets
        public virtual DbSet<Bucket> Buckets { get; set; }
        public virtual DbSet<UserBucket> UserBuckets { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        // End Budgets

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

                entity.Property(e => e.Amount).HasColumnType(AmountColumnType);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(GetDate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartingAmount).HasColumnType(AmountColumnType);

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

                entity.Property(e => e.Amount).HasColumnType(AmountColumnType);

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

                entity.Property(e => e.Amount).HasColumnType(AmountColumnType);

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

            modelBuilder.Entity<Bucket>(entity =>
            {
                entity.ToTable("Bucket", "Lookup");

                entity.HasIndex(e => e.BucketConstant)
                    .IsUnique();

                entity.Property(e => e.BucketId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Percentage).HasColumnType(PercentageColumnType);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(GetDate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BucketConstant)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasData(
                    new Bucket()
                    {
                        BucketId = Guid.Parse("7DACD09D-EA60-47E3-A256-44D6648EC31A"),
                        BucketConstant = "FIXED",
                        Name = "Fixed"
                    },
                    new Bucket()
                    {
                        BucketId = Guid.Parse("4C6D99B8-3AF2-4DC6-8976-353EC9940275"),
                        BucketConstant = "INVESTMENTS",
                        Name = "Investments"
                    },
                    new Bucket()
                    {
                        BucketId = Guid.Parse("8CDAF6B9-6F66-4699-B689-C88BA1DED997"),
                        BucketConstant = "SAVINGS",
                        Name = "Savings"
                    },
                    new Bucket()
                    {
                        BucketId = Guid.Parse("71AEE0F2-B303-44DF-8B48-5D9B8A33CA52"),
                        BucketConstant = "GUILTFREE",
                        Name = "Guilt Free Spending"
                    }
                );
            });

            modelBuilder.Entity<UserBucket>(entity =>
            {
                entity.ToTable("UserBucket", "UBudget");

                entity.Property(e => e.BucketId)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Percentage)
                    .HasColumnType(PercentageColumnType);

                entity.HasOne(x => x.Bucket)
                    .WithMany();

                entity.HasOne(typeof(User), nameof(UserBucket.UserId));
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.ToTable("LineItem", "UBudget");

                entity.Property(e => e.LineItemId)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FixedAmount)
                    .HasColumnType(AmountColumnType);

                entity.HasOne(typeof(User), nameof(UserBucket.UserId));

            });
        }
    }
}
