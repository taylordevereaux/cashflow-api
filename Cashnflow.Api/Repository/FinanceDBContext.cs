using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cashnflow.Api.Repository
{
    public partial class FinanceDBContext : DbContext
    {
        public FinanceDBContext()
        {
        }

        public FinanceDBContext(DbContextOptions<FinanceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<RepeatTransaction> RepeatTransaction { get; set; }
        public virtual DbSet<RepeatType> RepeatType { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-V7AHGCR;Initial Catalog=FinanceDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountTypeId).HasColumnName("AccountTypeID");

                entity.Property(e => e.Amount).HasColumnType("decimal(20, 6)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account__Account__4316F928");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasIndex(e => e.AccountTypeConstant)
                    .HasName("UQ__AccountT__5760C6A02CFA36EC")
                    .IsUnique();

                entity.Property(e => e.AccountTypeId).HasColumnName("AccountTypeID");

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

            modelBuilder.Entity<RepeatTransaction>(entity =>
            {
                entity.Property(e => e.RepeatTransactionId).HasColumnName("RepeatTransactionID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Amount).HasColumnType("decimal(20, 6)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RepeatTypeId).HasColumnName("RepeatTypeID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RepeatTransaction)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RepeatTra__Accou__46E78A0C");

                entity.HasOne(d => d.RepeatType)
                    .WithMany(p => p.RepeatTransaction)
                    .HasForeignKey(d => d.RepeatTypeId)
                    .HasConstraintName("FK__RepeatTra__Repea__47DBAE45");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.RepeatTransaction)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RepeatTra__Trans__45F365D3");
            });

            modelBuilder.Entity<RepeatType>(entity =>
            {
                entity.HasIndex(e => e.RepeatTypeConstant)
                    .HasName("UQ__RepeatTy__E7BDA05226F7167F")
                    .IsUnique();

                entity.Property(e => e.RepeatTypeId).HasColumnName("RepeatTypeID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RepeatTypeConstant)
                    .IsRequired()
                    .HasColumnType("Constant")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.HasIndex(e => e.TransactionTypeConstant)
                    .HasName("UQ__Transact__48A3C705759EB83E")
                    .IsUnique();

                entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");

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
