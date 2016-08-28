using LD36.Game_Entities.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LD36.Game_Entities.Scenes
{
    public class TitleScreen
        : Scene
    {
        public const string Title = "Title";

        private Texture2D _background;

        private Button _startButton;
        private Button _creditsButton;
        private Button _exitButton;

        private bool ContentLoaded;
        #region Initialize

        public override void Load(ContentManager content)
        {
            if (!ContentLoaded)
            {
                LoadTextures();
                LoadSounds();
                LoadControls();
            }

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Songs.Get(SongNames.CrystalHunterPreview));
        }
        public override void UnLoad()
        {
            MediaPlayer.Stop();
        }

        private void LoadTextures()
        {
            _background = Textures.Load(TextureNames.TitleWithBackground);

            Textures.Load(TextureNames.StartAdventureButton);
            Textures.Load(TextureNames.ExitGameButton);
            Textures.Load(TextureNames.CreditsButton);
        }

        private void LoadSounds()
        {
            Sounds.Load(SoundNames.CowMoo1);
            Sounds.Load(SoundNames.VintageButton1);

            Songs.Load(SongNames.CrystalHunterPreview);
        }

        private void LoadControls()
        {
            _startButton = new Button(TextureNames.StartAdventureButton, 512, 400, StartAdventure);
            _creditsButton = new Button(TextureNames.CreditsButton, 512, 480, Credits);
            _exitButton = new Button(TextureNames.ExitGameButton, 512, 560, ExitGame);
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
                Sounds.Play(SoundNames.CowMoo1);
            }

            if (Input.Keyboard.IsKeyPressed(Keys.Enter)
                || Input.GamePad.IsButtonPressed(PlayerIndex.One, LD36.Input.Buttons.A))
            {
                StartAdventure();
            }

            if (Input.Keyboard.IsKeyPressed(Keys.Space)
               || Input.GamePad.IsButtonPressed(PlayerIndex.One, LD36.Input.Buttons.X))
            {
                Credits();
            }

            if (Input.Keyboard.IsKeyPressed(Keys.Escape)
                || Input.GamePad.IsButtonPressed(PlayerIndex.One, LD36.Input.Buttons.Back)
                || Input.GamePad.IsButtonPressed(PlayerIndex.One, LD36.Input.Buttons.B))
            {
                ExitGame();
            }
        }

        private void UpdateControls(GameTime gameTime)
        {
            _startButton.Update(gameTime);
            _creditsButton.Update(gameTime);
            _exitButton.Update(gameTime);
        }

        #endregion

        #region Draw

        public override void Draw(GameTime gameTime)
        {
            ArchaicGame.Graphics.GraphicsDevice.Clear(Color.Black);

            // Need NonPremultiplied for transparencies to work
            SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);

            SpriteBatch.Draw(_background, ArchaicGame.ScreenBounds, Color.White);

            _startButton.Draw(gameTime);
            _creditsButton.Draw(gameTime);
            _exitButton.Draw(gameTime);

            SpriteBatch.End();
        }

        #endregion

        #region Actions

        public void StartAdventure()
        {
            Scenes.ChangeScene(CampScene.Title);
        }

        public void Credits()
        {
            Scenes.ChangeScene(CreditsScene.Title);
        }

        public void ExitGame()
        {
            ArchaicGame.Instance.Exit();
        }

        #endregion
    }
}
