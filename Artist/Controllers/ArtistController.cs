using Artist.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Artist.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ArtistDbContext _context;

        public ArtistController(ArtistDbContext context)
        {
            _context = context;
        }

        // Відображення списку всіх художників
        public IActionResult Index()
        {
            var artists = _context.Artists.ToList();
            return View(artists);
        }

        // Додавання нового художника
        [HttpPost]
        public IActionResult Add(string artistName, string artMovement, string country, DateTime birthDate, string bio)
        {
            var artist = new ArtistModel
            {
                ArtistName = artistName,
                ArtMovement = artMovement,
                Country = country,
                BirthDate = birthDate,
                Bio = bio
            };
            _context.Artists.Add(artist);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Видалення художника
        public IActionResult Delete(int id)
        {
            var artist = _context.Artists.Find(id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Додавання художника в улюблені
        public IActionResult AddToFavorites(int artistId)
        {
            var artist = _context.Artists.Find(artistId);
            if (artist != null)
            {
                var favoriteArtist = new FavoriteArtistModel
                {
                    ArtistID = artist.ArtistID,
                    AddedDate = DateTime.Now
                };
                _context.FavoriteArtists.Add(favoriteArtist);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
