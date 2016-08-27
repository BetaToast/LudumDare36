using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LD36.Scenes
{
    public class TitleScreen 
		: Scene
    {
		private Texture2D _background;
	    
		public const string Title = "Title";

		#region Initialize

		public override void LoadContent(ContentManager content)
		{
			_background = Textures.Load(TextureNames.TitleWithBackground);
			Sounds.Load(SoundNames.CowMoo);
		}

		#endregion

		#region Update

		public override void Update(GameTime gameTime)
		{
			UpdateInput();
			base.Update(gameTime);
		}

	    private void UpdateInput()
	    {
			if (Input.Keyboard.IsKeyPressed(Keys.M))
			{
				Sounds.Play(SoundNames.CowMoo);
			}

		    if (Input.Keyboard.IsKeyPressed(Keys.Escape)
		        || Input.GamePad.IsButtonPressed(PlayerIndex.One, LD36.Input.Buttons.Back))
		    {
			    ArchaicGame.Instance.Exit();
		    }
		}

		#endregion

		#region Draw

		public override void Draw(GameTime gameTime)
        {
            ArchaicGame.Graphics.GraphicsDevice.Clear(Color.Black);

			SpriteBatch.Begin();

			SpriteBatch.Draw(_background, ArchaicGame.ScreenBounds, Color.White);

			SpriteBatch.End();
		}

		#endregion
    }
}
