using System;
using System.Collections.Generic;
using Library_Management.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.Data;

public partial class BookDbContext : DbContext
{
    public BookDbContext()
    {
    }

    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAuthor> TblAuthors { get; set; }

    public virtual DbSet<TblBook> TblBooks { get; set; }

    public virtual DbSet<TblBookCopy> TblBookCopies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Librarydb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAuthor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblAuthor");

            entity.Property(e => e.Biography)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProfileImageUrl)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblBook");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblBookCopy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblBookCopy");

            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CoverImageUrl)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PullOutDate).HasColumnType("datetime");
            entity.Property(e => e.PullOutReason)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Source)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
