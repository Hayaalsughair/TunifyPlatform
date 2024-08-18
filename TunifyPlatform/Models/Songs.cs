namespace TunifyPlatform.Models
{
    public class Songs
    {
        public int SongsId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set;}//FK
        public int Album_Id { get; set;}//FK
        public string Duration { get; set; }
        public string Genre { get; set; }

        //Many to many Relationship
        public ICollection<PlaylistSongs> PlaylistSongs { get; set; }


        // Navigation property to Artists
        public Artists Artist { get; set; }

    }
}
