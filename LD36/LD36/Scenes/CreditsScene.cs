using LD36.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LD36.Scenes
{
    public class CreditsScene
        : Scene
    {
        public const string Title = "Credits";

        private SpriteFont _font;
        private Texture2D _background;
        private Texture2D _overlay;
        private Texture2D _whitePixel;
        private bool ContentLoaded;
        private bool InitialSpriteBatchDrawn;

        #region Initialize
        public override void Load(ContentManager content)
        {
            if (!ContentLoaded)
            {
                LoadTextures();
                LoadSounds();
                LoadControls();

                ContentLoaded = true;
            }
            InitialSpriteBatchDrawn = false;
            Songs.PlayRepeating(SongNames.Morning);
        }

        public override void UnLoad()
        {
            MediaPlayer.Stop();
        }

        private void LoadTextures()
        {
            _background = Textures.Load(TextureNames.TitleBackground);
            _overlay = Textures.Load(TextureNames.TitleText);
            _whitePixel = Textures.Get(TextureNames.WhitePixel);

            _font = Fonts[FontNames.Default];
        }

        private void LoadSounds()
        {
            Songs.Load(SongNames.Morning);
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
            if (Input.Keyboard.IsAnyKeyPressed()
                || Input.GamePad.IsAnyButtonPressed(PlayerIndex.One)
                || Input.Mouse.IsAnyButtonPressed())
            {
                ReturnToTitle();
            }
        }

        private void UpdateControls(GameTime gameTime)
        {

        }

        #endregion

        #region Draw

        public override void Draw(GameTime gameTime)
        {
            if (!InitialSpriteBatchDrawn)
            {
                DrawSpriteBatch();
            }
        }
        private void DrawSpriteBatch()
        {
            ArchaicGame.Graphics.GraphicsDevice.Clear(Color.Black);

            // Need NonPremultiplied for transparencies to work
            SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);

            SpriteBatch.Draw(_background, ArchaicGame.ScreenBounds, Color.White);
            SpriteBatch.Draw(_whitePixel, new Rectangle(0, 96, ArchaicGame.ScreenWidth, 168), Color.White.WithOpacity(0.5f));
            SpriteBatch.Draw(_overlay, ArchaicGame.ScreenBounds.Translate(0, -32), Color.White);

            SpriteBatch.DrawString(_font, "Design / Programming / Art / Sounds", new Vector2(380, 270), Color.Black);

            SpriteBatch.DrawString(_font, "Aaron Foley (@slyprid)", new Vector2(480, 318), Color.Black);
            SpriteBatch.DrawString(_font, "Ryan Forster (@xenoputtss)", new Vector2(450, 350), Color.Black);
            SpriteBatch.DrawString(_font, "Jeff Pierson (@kainhart)", new Vector2(460, 382), Color.Black);

            SpriteBatch.DrawString(_font, "Testing", new Vector2(540, 500), Color.Black);

            SpriteBatch.DrawString(_font, "For Ludum Dare 36 - August 26 - 29 - 2016", new Vector2(340, 600), Color.Black);
            SpriteBatch.DrawString(_font, "http://LudumDare.com", new Vector2(450, 632), Color.Black);

            SpriteBatch.End();
        }


        #endregion

        #region Actions

        public void ReturnToTitle()
        {
            Scenes.ChangeScene(TitleScreen.Title);
        }

        #endregion
    }
}
