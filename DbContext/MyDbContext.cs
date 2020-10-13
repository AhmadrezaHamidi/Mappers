
using BookAndShelve.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndShelve.DbContext
{
    public class MyDbContext : IdentityDbContext<Tbuser>
    {
        public MyDbContext() : base()
        {

        }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = .; Database=bookAndShelveData;Integrated Security = true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<tbBook>(e =>
            {
                e.HasMany(p => p.BookAndShelves).WithOne(p => p.book).HasForeignKey(X => X.BookID);
                e.HasKey(p => p.Id);
                e.ToTable("Book");
            });
            builder.Entity<TbBookAndShelve>(e =>
            {
                e.HasKey(p => p.Id);
                e.ToTable("BookAndShelve");
            });
            builder.Entity<TbUserRole>(e =>
            {
                e.HasOne(x => x.User).WithMany(x => x.userRoles).HasForeignKey(x => x.UserId);
                e.HasOne(x => x.Role).WithMany(X => X.userRoles).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<Tbuser>(e =>
            {
                ///  e.Property(x => x.Birthday).HasDefaultValue("getdate()");

                e.HasKey(X => X.Id);
                e.ToTable("User");
            });
            builder.Entity<Tbshelve>(e =>
            {
                e.HasOne(x => x.User).WithMany(x => x.Shelves).HasForeignKey(p => p.UserId);
                e.HasMany(x => x.bookAndShelvecs).WithOne(x => x.shelve).HasForeignKey(x => x.Shelved);
                e.HasKey(X => X.Id);
                e.ToTable("shelves");
            });

        }
        public DbSet<Tbuser> users { get; set; }
        public DbSet<tbBook> Bookes { get; set; }
        public DbSet<Tbshelve> Shelves { get; set; }
        public DbSet<TbBookAndShelve> BookAndShelvecs { get; set; }

    }
}

