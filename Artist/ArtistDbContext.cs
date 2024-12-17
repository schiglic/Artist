using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Artist.Models
{
    public class ArtistDbContext : IdentityDbContext<ApplicationUser>  // Успадковуємо від IdentityDbContext
    {
        public ArtistDbContext(DbContextOptions<ArtistDbContext> options) : base(options) { }

        // DbSet для моделей художників та улюблених художників
        public DbSet<ArtistModel> Artists { get; set; }
        public DbSet<FavoriteArtistModel> FavoriteArtists { get; set; }

        // Перевизначення методу OnModelCreating для налаштування бази даних
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Завжди викликаємо метод базового класу

            // Налаштовуємо первинний ключ для FavoriteArtistModel
            modelBuilder.Entity<FavoriteArtistModel>()
                .HasKey(f => f.FavoriteArtistID);
        }
    }
}
