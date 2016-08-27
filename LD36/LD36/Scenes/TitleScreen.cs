using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LD36.Scenes
{
    public class TitleScreen
        : Scene
    {
		private SpriteBatch _spriteBatch;
		private Texture2D _background;

		public const string Title = "Title";

		public override void LoadContent(ContentManager content)
		{
			_spriteBatch = new SpriteBatch(AdventureGame.Graphics.GraphicsDevice);
			_background = content.Load<Texture2D>("PiriReis"); // change these names to the names of your images

		}

		public override void Draw(GameTime gameTime)
        {
            AdventureGame.Graphics.GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin();

			_spriteBatch.Draw(_background, new Rectangle(0, 0, 800, 480), Color.White);

			_spriteBatch.End();
		}
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
			
			}
            base.Update(gameTime);
        }

    }
}
