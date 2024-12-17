namespace Artist.Models
{
    public class FavoriteArtistModel  // Змінили на FavoriteArtist
    {
        public int FavoriteArtistID { get; set; }
        public int ArtistID { get; set; }
        public DateTime AddedDate { get; set; }

        public ArtistModel Artist { get; set; }
    }
}
