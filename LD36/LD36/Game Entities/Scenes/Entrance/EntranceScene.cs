using LD36.Characters;
using LD36.Extensions;
using LD36.Game_Entities.Objects;
using LD36.Game_Entities.Scenes.Camp;
using LD36.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LD36.Game_Entities.Scenes.Entrance
{
	public class EntranceScene
		: Scene
	{
		public const string Title = "Entrance";

		private Texture2D _background;
		private Texture2D _overlay1;
		private Player _player => ArchaicGame.Player;

		#region Initialize

		public override void Load(ContentManager content)
		{
			if (!ContentLoaded)
			{
				LoadTextures();
				LoadSounds();
				LoadControls();
				LoadEntities();
			}
		}

		public override void UnLoad() { }

		private void LoadTextures()
		{
			_background = Textures.Load(TextureNames.EntranceBackground);
			_overlay1 = Textures.Load(TextureNames.EntranceBackgroundOverlay1);
		}

		private void LoadSounds()
		{

		}

		private void LoadControls()
		{

		}

		private void LoadEntities()
		{
			Entities.Clear();
			var campTransition = new SceneTransition(new Vector2(0, 243), new Vector2(64, 477), CampScene.Title);
			campTransition.OnTransition = GoToCampScene;
			Entities.Add(campTransition);
		}

		#endregion

		#region Update

		public override void Update(GameTime gameTime)
		{
			UpdateInput();
			UpdateControls(gameTime);
			UpdatePlayer(gameTime);

			base.Update(gameTime);
		}

		private void UpdateInput()
		{
			if (Input.Keyboard.IsKeyPressed(Keys.M))
			{
				Sounds.Play(SoundNames.CowMoo1);
			}

			if (Input.Keyboard.IsKeyPressed(Keys.Escape)
				|| Input.GamePad.IsButtonPressed(PlayerIndex.One, LD36.Input.Buttons.Back))
			{
				ExitGame();
			}

			if (Input.Mouse.IsButtonHeld(MouseButtons.Left))
			{
				var mx = Input.Mouse.CurrentPosition.X;
				var my = Input.Mouse.CurrentPosition.Y;
				if (mx > 0 && my > 0)
				{
					_player.Destination = new Vector2(mx, my);
				}
			}
		}

		private void UpdateControls(GameTime gameTime)
		{
			foreach (var entity in Entities)
			{
				entity.Update(gameTime);
			}
		}

		private void UpdatePlayer(GameTime gameTime)
		{
			_player.Update(gameTime);
		}

		#endregion

		#region Draw

		public override void Draw(GameTime gameTime)
		{
			ArchaicGame.Graphics.GraphicsDevice.Clear(Color.Black);

			// Need NonPremultiplied for transparencies to work
			SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
				SpriteBatch.Draw(_background, Vector2.Zero, Color.White);
				foreach (var entity in Entities)
				{
					entity.Draw(gameTime);
				}

				_player.Draw(gameTime);
				SpriteBatch.Draw(_overlay1, new Vector2(1195, 4), Color.White);
			SpriteBatch.End();
		}

		#endregion

		#region Actions
		public void ExitGame()
		{
			Scenes.ChangeScene(TitleScreen.Title);
		}

		public void GoToCampScene()
		{
			_player.Position = _player.Position.SetX(ArchaicGame.ScreenWidth - _player.Size.X - 65);
		}

		#endregion
	}
}