using LD36.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LD36
{
    public class AdventureGame 
		: Game
    {
		public static SceneManager Scenes  { get; set; }	
		public static GraphicsDeviceManager Graphics { get; set; }
        public static SpriteBatch SpriteBatch  { get; set; }
		public static ContentManager ContentManager { get; set; }

        public AdventureGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
	        ContentManager = Content;
        }

        protected override void Initialize()
        {
			Scenes = new SceneManager();
            Scenes.AddScene(TitleScreen.Title, new TitleScreen());
            Scenes.AddScene(CampScene.Title, new CampScene());
            Scenes.AddScene(Maze1Scene.Title, new Maze1Scene());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
	        Scenes.ChangeScene(TitleScreen.Title);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

	        Scenes.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

	        Scenes.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
