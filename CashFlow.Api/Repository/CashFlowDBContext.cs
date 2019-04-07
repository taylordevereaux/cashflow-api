using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CashFlow.Api.Repository
{
    public partial class CashFlowDBContext : DbContext
    {
        public CashFlowDBContext()
        {
        }

        public CashFlowDBContext(DbContextOptions<CashFlowDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<RecurringTransaction> RecurringTransaction { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DBConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account", "CashFlow");

                entity.Property(e => e.AccountId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(20, 6)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartingAmount).HasColumnType("decimal(20, 6)");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account__AccountTypeId");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountType", "Lookup");

                entity.HasIndex(e => e.AccountTypeConstant)
                    .HasName("UQ__AccountT__5760C6A068E0D90D")
                    .IsUnique();

                entity.Property(e => e.AccountTypeConstant)
                    .IsRequired()
                    .HasColumnType("Constant")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RecurringTransaction>(entity =>
            {
                entity.ToTable("RecurringTransaction", "CashFlow");

                entity.HasIndex(e => e.ScheduleId)
                    .HasName("UNQ_TRANS_SCHED_ID")
                    .IsUnique();

                entity.Property(e => e.Amount).HasColumnType("decimal(20, 6)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RecurringTransaction)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recurring__AccountId");

                entity.HasOne(d => d.Schedule)
                    .WithOne(p => p.RecurringTransaction)
                    .HasForeignKey<RecurringTransaction>(d => d.ScheduleId)
                    .HasConstraintName("FK__Recurring__ScheduleId");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.RecurringTransaction)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recurring__TransactionTypeId");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule", "CashFlow");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

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

                entity.Property(e => e.Amount).HasColumnType("decimal(20, 6)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transaction_AccountId");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transaction_TransactionTypeId");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("TransactionType", "Lookup");

                entity.HasIndex(e => e.TransactionTypeConstant)
                    .HasName("UQ__Transact__48A3C705D654D116")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionTypeConstant)
                    .IsRequired()
                    .HasColumnType("Constant")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
