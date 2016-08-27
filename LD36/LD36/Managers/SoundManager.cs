using Microsoft.Xna.Framework.Media;

namespace LD36.Managers
{
	public class SoundManager
		: Manager<Song>
	{
		public Song Play(string soundName)
		{
			var song = Get(soundName);
			MediaPlayer.Play(song);
			return song;
		}
	}
}