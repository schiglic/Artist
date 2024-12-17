using Microsoft.EntityFrameworkCore;
using Artist.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Artist.Controllers
{
    public class FavoriteArtistsController : Controller
    {
        private readonly ArtistDbContext _context;

        public FavoriteArtistsController(ArtistDbContext context)
        {
            _context = context;
        }

        // Відображення вибраних художників
        public IActionResult Index()
        {
            // Завантажуємо список улюблених художників разом з інформацією про художників
            var favoriteArtists = _context.FavoriteArtists
                .Include(f => f.Artist) // Завантажуємо художника
                .Select(f => new FavoriteArtistModel
                {
                    FavoriteArtistID = f.FavoriteArtistID, // Замінили на FavoriteArtistID
                    ArtistID = f.ArtistID,
                    AddedDate = f.AddedDate,
                    Artist = f.Artist // Завантажуємо повний об'єкт Artist
                })
                .ToList();

            // Повертаємо вигляд для цих даних
            return View("Index", favoriteArtists); // Вказуємо назву вигляду
        }

        // Додавання художника в список вибраних
        public IActionResult AddToFavorites(int artistId)
        {
            // Шукаємо художника за його ID
            var artist = _context.Artists.Find(artistId);
            if (artist != null)
            {
                // Створюємо новий запис для улюбленого художника
                var favoriteArtist = new FavoriteArtistModel
                {
                    ArtistID = artist.ArtistID,
                    AddedDate = DateTime.Now
                };

                _context.FavoriteArtists.Add(favoriteArtist);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "FavoriteArtists"); // Повертаємося до списку улюблених
        }

        // Видалення художника зі списку вибраних
        public IActionResult RemoveFromFavorites(int id)
        {
            // Шукаємо запис у списку улюблених за його ID
            var favoriteArtist = _context.FavoriteArtists.Find(id);
            if (favoriteArtist != null)
            {
                _context.FavoriteArtists.Remove(favoriteArtist);
                _context.SaveChanges();
            }
            return RedirectToAction("Index"); // Повертаємося до списку улюблених художників
        }
    }
}
