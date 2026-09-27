using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Models;

namespace MyMediaShelf.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<MediaItem> MediaItem { get; set; } = default!;
        public DbSet<MediaType> MediaType { get; set; } = default!;
        public DbSet<MediaFormat> MediaFormat { get; set; } = default!;
        public DbSet<CollectionItem> CollectionItem { get; set; } = default!;
        public DbSet<Collection> Collection { get; set; } = default!;
    }
}
