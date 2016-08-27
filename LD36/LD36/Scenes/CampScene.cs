using LD36.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LD36.Scenes
{
	public  class CampScene
		:  Scene
	{
        public const string Title = "Camp";
		
		private Texture2D _background;
		
		#region Initialize

		public override void LoadContent(ContentManager content)
		{
			LoadTextures();
			LoadSounds();
			LoadControls();
		}

		private void LoadTextures()
		{
			_background = Textures.Load(TextureNames.CampBackground);

			Textures.Load(TextureNames.StartAdventureButton);
			Textures.Load(TextureNames.ExitGameButton);
			Textures.Load(TextureNames.CreditsButton);
		}

		private void LoadSounds()
		{
			Sounds.Load(SoundNames.CowMoo);
		}

		private void LoadControls()
		{
			
		}

		#endregion

		#region Update

		public override void Update(GameTime gameTime)
		{
			UpdateInput();
			UpdateControls(gameTime);
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
				ExitGame();
			}
		}

		private void UpdateControls(GameTime gameTime)
		{
			
		}

		#endregion

		#region Draw

		public override void Draw(GameTime gameTime)
		{
			ArchaicGame.Graphics.GraphicsDevice.Clear(Color.Black);

			// Need NonPremultiplied for transparencies to work
			SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);

			SpriteBatch.Draw(_background, ArchaicGame.ScreenBounds, Color.White);
			
			SpriteBatch.End();
		}

		#endregion

		#region Actions
		
		public void ExitGame()
		{
			Scenes.ChangeScene(TitleScreen.Title);
		}

		#endregion
	}
}
