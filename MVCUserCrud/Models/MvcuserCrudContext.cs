using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCUserCrud.Models;

public partial class MvcuserCrudContext : DbContext
{
    public MvcuserCrudContext()
    {
    }

    public MvcuserCrudContext(DbContextOptions<MvcuserCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserList> UserLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = Dipesh;Initial Catalog=MVCUserCrud;Integrated Security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserList>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserList__1788CC4CF40ED439");

            entity.ToTable("UserList");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.EmailAddress).HasMaxLength(50);
            entity.Property(e => e.UserAddress).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(40);
            entity.Property(e => e.UserRole).HasMaxLength(50);
            entity.Property(e => e.UserStatus).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
