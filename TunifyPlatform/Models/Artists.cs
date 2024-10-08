﻿namespace TunifyPlatform.Models
{
    public class Artists
    {
        public int ArtistsId { get; set; }//PK
        public string Name { get; set; }
        public string Bio { get; set; }

        //Artist can have many songs 
        public ICollection<Songs> Songs { get; set; }
    }
}
