using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LD36.Scenes
{
    public class TitleScreen : Scene
    {
        public const string Title = "Title";

        public override void Draw(GameTime gameTime)
        {
            AdventureGame.Graphics.GraphicsDevice.Clear(Color.Black);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                MediaPlayer.Play(AdventureGame.sounds["CowMoo1"]);
            }
            base.Update(gameTime);
        }

    }
}
