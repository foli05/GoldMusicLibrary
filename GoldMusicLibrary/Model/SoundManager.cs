using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldMusicLibrary.Model
{
    public static class SoundManager
    {
        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allsounds = getSounds();
            sounds.Clear();
            allsounds.ForEach(sound => sounds.Add(sound));
        }

        public static void GetSoundsbyGenre(ObservableCollection<Sound> sounds, GenreSelection genre)
        {
            var allsounds = getSounds();
            var filteredSounds = allsounds.Where(sound => sound.Genre == genre).ToList();
            sounds.Clear();
            filteredSounds.ForEach(sound => sounds.Add(sound));
        }

        private static List<Sound> getSounds()
        {
            var sounds = new List<Sound>();
            sounds.Add(new Sound("Anthem", GenreSelection.Country));
            sounds.Add(new Sound("OneMan", GenreSelection.Country));
            sounds.Add(new Sound("Lex", GenreSelection.Electronic));
            sounds.Add(new Sound("Xylo", GenreSelection.Electronic));
            sounds.Add(new Sound("Cloud", GenreSelection.Jazz));
            sounds.Add(new Sound("Feather", GenreSelection.Jazz));
            sounds.Add(new Sound("Celebrate", GenreSelection.RnB));
            sounds.Add(new Sound("SunnyDays", GenreSelection.RnB));

            return sounds;
        }
    }

}
