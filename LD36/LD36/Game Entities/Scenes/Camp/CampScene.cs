using LD36.Characters;
using LD36.Extensions;
using LD36.Game_Entities.Objects;
using LD36.Game_Entities.Scenes.Entrance;
using LD36.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LD36.Game_Entities.Scenes.Camp
{
    public class CampScene
        : Scene
    {
        public const string Title = "Camp";

        private Texture2D _background;
        private Player _player => ArchaicGame.Player;

        #region Initialize

        public override void Load(ContentManager content)
        {
            if (!ContentLoaded)
            {
                _player.Position = new Vector2(624, 344);
                LoadTextures();
                LoadSounds();
                LoadControls();
	            LoadEntities();
	            ContentLoaded = true;
            }
        }

		public override void UnLoad() { }

        private void LoadTextures()
        {
            _background = Textures.Load(TextureNames.CampBackground);

            Textures.Load(TextureNames.StartAdventureButton);
            Textures.Load(TextureNames.ExitGameButton);
            Textures.Load(TextureNames.CreditsButton);
        }

        private void LoadSounds()
        {
            Sounds.Load(SoundNames.CowMoo1);
        }

        private void LoadControls()
        {
            
        }

	    private void LoadEntities()
	    {
		    Entities.Clear();

			Entities.Add(new MagicSquare(new Vector2(200, 275), () => { }));

		    var entranceTransition = new SceneTransition(new Vector2(1215, 243), new Vector2(64, 477), EntranceScene.Title);
		    entranceTransition.OnTransition = GoToEntranceScene;
			Entities.Add(entranceTransition);
		}

        #endregion

        #region Update

        public override void Update(GameTime gameTime)
        {
            UpdateInput();
            UpdateControls(gameTime);
            UpdatePlayer(gameTime);

            CreateItem(gameTime);
            base.Update(gameTime);
        }

        private void CreateItem(GameTime gameTime)
        {


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

				SpriteBatch.Draw(_background, ArchaicGame.ScreenBounds, Color.White);

				foreach (var entity in Entities)
				{
					entity.Draw(gameTime);
				}

				_player.Draw(gameTime);

            SpriteBatch.End();
        }

        #endregion

        #region Actions

        public void ExitGame()
        {
            Scenes.ChangeScene(TitleScreen.Title);
        }

	    public void GoToEntranceScene()
	    {
		    _player.Position = _player.Position.SetX(0);
	    }

		#endregion
	}
}
