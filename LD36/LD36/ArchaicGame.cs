using System;
using LD36.Characters;
using LD36.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LD36.Managers;

namespace LD36
{
    public class ArchaicGame
        : Game
    {
        #region Globals

        public static ArchaicGame Instance { get; private set; }
        public static SceneManager Scenes { get; set; }
        public static GraphicsDeviceManager Graphics { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static ContentManager ContentManager { get; set; }
        public static Vector2 Resolution { get; set; }
        public static Random Random { get; private set; }
        public static Player Player { get; set; }

        public static int ScreenWidth => (int)Resolution.X;
        public static int ScreenHeight => (int)Resolution.Y;
        public static Rectangle ScreenBounds => new Rectangle(0, 0, ScreenWidth, ScreenHeight);

        #region Managers
        public static SoundManager Sounds { get; } = new SoundManager();
        public static TextureManager Textures { get; } = new TextureManager();
        public static InputManager Input { get; } = new InputManager();
        public static FontManager Fonts { get; } = new FontManager();
        public static SongManager Songs { get; } = new SongManager();
        #endregion

        #endregion

        #region Initialization

        public ArchaicGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ContentManager = Content;

            IsMouseVisible = true;
            ChangeResolution(1280, 720);
            Window.Title = "Archaic";

            Random = new Random();

            Instance = this;
        }

        protected override void Initialize()
        {

            Fonts.Load(FontNames.Default);

            Scenes = new SceneManager();
            Scenes.AddScene(TitleScreen.Title, new TitleScreen());
            Scenes.AddScene(CreditsScene.Title, new CreditsScene());
            Scenes.AddScene(CampScene.Title, new CampScene());
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            var whitePixel = Textures.Load(TextureNames.WhitePixel, new Texture2D(GraphicsDevice, 1, 1));
            whitePixel.SetData(new[] { Color.White });

            Player = new Player(whitePixel);

            Scenes.ChangeScene(TitleScreen.Title);
        }

        #endregion

        #region Main Update

        protected override void Update(GameTime gameTime)
        {
            Input.Update(gameTime);
            Scenes.Update(gameTime);

            base.Update(gameTime);
        }

        #endregion

        #region Main Draw

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Scenes.Draw(gameTime);

            base.Draw(gameTime);
        }

        #endregion

        #region Global Methods / Functions

        public static void ChangeResolution(int width, int height)
        {
            Resolution = new Vector2(width, height);
            Graphics.PreferredBackBufferWidth = width;
            Graphics.PreferredBackBufferHeight = height;
            Graphics.ApplyChanges();
        }

        #endregion
    }
}
