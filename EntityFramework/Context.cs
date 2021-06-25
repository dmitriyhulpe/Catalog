using Catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.EnsureCreated();
        }

        public DbSet<Member> Member { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public Context(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(End =>
            {
                End.HasKey(category => category.CategoryID);
                End.Property(category => category.CategoryName).HasMaxLength(30);
            });

            modelBuilder.Entity<Member>(End =>
            {
                End.HasKey(member => member.MemberID);
                End.Property(member => member.MemberName).HasMaxLength(30);
                End.Property(member => member.Password).HasMaxLength(30);
                End.Property(member => member.Email).HasMaxLength(30);
                End.Property(member => member.Phone).HasMaxLength(30);
            });

            modelBuilder.Entity<Product>(End =>
            {
                End.HasKey(product => product.ProductID);
                End.Property(product => product.ProductName).HasMaxLength(30);
                End.Property(product => product.Description).HasMaxLength(30);
                End.Property(product => product.Price).HasPrecision(9, 2);

                End.HasMany(product => product.CartMember).WithMany(member => member.CartProduct).UsingEntity(join => join.ToTable("Cart"));
                End.HasMany(product => product.WishlistMember).WithMany(member => member.WishlistProduct).UsingEntity(join => join.ToTable("WishList"));
                End.HasOne(product => product.Category).WithMany(category => category.Product).HasForeignKey(product => product.CategoryID);
            });

            modelBuilder.Entity<Transaction>(End =>
            {
                End.HasKey(transaction => transaction.TransactionID);
                End.Property(transaction => transaction.Quantity);
                End.Property(transaction => transaction.TotalPrice).HasPrecision(9, 2);
                End.Property(transaction => transaction.Date).HasColumnType("date").IsRequired();

                End.HasOne(transaction => transaction.Member).WithMany(transaction => transaction.Transaction).HasForeignKey(product => product.MemberID);
                End.HasOne(transaction => transaction.Product).WithMany(transaction => transaction.Transaction).HasForeignKey(product => product.ProductID);
            });
        }
    }
}