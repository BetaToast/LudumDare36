using Microsoft.Xna.Framework.Audio;

namespace LD36.Managers
{
    public class SoundManager : Manager<SoundEffect>
    {
        public void Play(string soundName)
        {
            Get(soundName)?.Play();
        }
    }
}