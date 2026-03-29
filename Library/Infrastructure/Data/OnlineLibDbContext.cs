using Library.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data;

public class OnlineLibDbContext:IdentityDbContext<AppUser>
{
    public OnlineLibDbContext(DbContextOptions<OnlineLibDbContext> options) : base(options)
    {
        
    }

    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<UserBook> UserBooks => Set<UserBook>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AppUser>(
            u =>
            {
                u.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);
                
                u.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                u.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);
                
                u.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                u.Property(e => e.CreatedAt)
                    .IsRequired();
                
                u.Property(e => e.Birthday)
                    .IsRequired();

                u.Property(e => e.UpdatedAt);
            }
        );
        modelBuilder.Entity<Book>(
            b =>
            {
                b.Property(c => c.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                b.Property(c => c.AuthorName)
                    .IsRequired()
                    .HasMaxLength(50);

                b.Property(c => c.CreatedAt)
                    .IsRequired();

                b.Property(c => c.UpdatedAt);

            }
        );
        modelBuilder.Entity<UserBook>(ub =>
        {
            ub.HasKey(x => new { x.UserId, x.BookId }); 

            ub.HasOne<AppUser>()
                .WithMany(u => u.UserBooks)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            ub.HasOne(x => x.Book)
                .WithMany(b => b.UserBooks)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<RefreshToken>(rt =>
        {
            rt.HasKey(x => x.Id);

            rt.Property(x => x.Token).IsRequired();
            
            rt.Property(x => x.ExpiresAt).IsRequired();

            rt.HasOne<AppUser>()
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}