using LD36.Characters;
using LD36.Controls;
using LD36.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LD36.Scenes
{
    public class CampScene
        : Scene
    {
        public const string Title = "Camp";

        private Texture2D _background;
        private Player _player => ArchaicGame.Player;
        private bool ContentLoaded;
        #region Initialize

        public override void Load(ContentManager content)
        {
            if (!ContentLoaded)
            {
                _player.Position = new Vector2(624, 344);
                LoadTextures();
                LoadSounds();
                LoadControls();
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

            if (Input.Mouse.IsButtonPressed(MouseButtons.Left))
            {
                _player.Destination = new Vector2(Input.Mouse.CurrentPosition.X, Input.Mouse.CurrentPosition.Y);
            }
        }

        private void UpdateControls(GameTime gameTime)
        {

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

            _player.Draw(gameTime);

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
