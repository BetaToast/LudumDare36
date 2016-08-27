using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LD36.Scenes
{
	public class _TemplateScene
		: Scene
	{
		public const string Title = "Template";

		#region Initialize

		public override void LoadContent(ContentManager content)
		{
			LoadTextures();
			LoadSounds();
			LoadControls();
		}

		private void LoadTextures()
		{

		}

		private void LoadSounds()
		{

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

			SpriteBatch.End();
		}

		#endregion

		#region Actions

		#endregion
	}
}
