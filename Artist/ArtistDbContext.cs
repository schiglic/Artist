using Microsoft.EntityFrameworkCore;

namespace Artist.Models
{
    public class ArtistDbContext : DbContext
    {
        public ArtistDbContext(DbContextOptions<ArtistDbContext> options) : base(options) { }

        // DbSet для моделей художників та улюблених художників
        public DbSet<ArtistModel> Artists { get; set; }
        public DbSet<FavoriteArtistModel> FavoriteArtists { get; set; }  // Ось тут ми використовуємо сутність FavoriteArtist

        // Перевизначення методу OnModelCreating для налаштування бази даних
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Налаштовуємо, що FavoriteArtist має первинний ключ
            modelBuilder.Entity<FavoriteArtistModel>()
                .HasKey(f => f.FavoriteArtistID);  // Вказуємо, що поле FavoriteArtistID є первинним ключем для сутності FavoriteArtist

            // Важливо: Завжди викликайте метод базового класу
            base.OnModelCreating(modelBuilder);
        }
    }
}
