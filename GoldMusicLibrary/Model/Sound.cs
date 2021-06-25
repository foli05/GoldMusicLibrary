using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldMusicLibrary.Model
{
    public enum GenreSelection
    { Country,
      Electronic,
      Jazz,
      RnB
    }
    public class Sound
    {
        public string Name { get; set; }
        public GenreSelection Genre { get; set; }
        public string CoverImage { get; set; }
        public string MusicFile { get; set; }
     
        public Sound(string name, GenreSelection genre)
        {
            Name = name;
            Genre = genre;
            MusicFile = $"/Assets/Music/{genre}/{name}.mp3";
            CoverImage = $"/Assets/Cover Image/{genre}/{name}.jpeg";
        }

    }
}
