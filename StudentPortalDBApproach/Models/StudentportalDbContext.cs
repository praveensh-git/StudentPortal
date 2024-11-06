using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentPortalDBApproach.Models;

public partial class StudentportalDbContext : DbContext
{
    public StudentportalDbContext()
    {
    }

    public StudentportalDbContext(DbContextOptions<StudentportalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Students11> Students11s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Students11>(entity =>
        {
            entity.ToTable("Students11");

            entity.HasIndex(e => e.StudentId, "IX_Students11_StudentId");

            entity.HasOne(d => d.Student).WithMany(p => p.Students11s)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
