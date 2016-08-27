using Microsoft.Xna.Framework.Media;

namespace LD36.Managers
{
    public class SongManager : Manager<Song>
    {
        public void Play(string songName)
        {
            var song = Get(songName);
            MediaPlayer.Play(song);
        }

        public void PlayRepeating(string songName)
        {
            MediaPlayer.IsRepeating = true;
            Play(songName);
        }
    }
}