using LD36.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LD36.Scenes
{
	public class Scene
	{
		public bool IsLoaded { get; set; }

		public SpriteBatch SpriteBatch => ArchaicGame.SpriteBatch;
		public TextureManager Textures => ArchaicGame.Textures;
		public SoundManager Sounds => ArchaicGame.Sounds;
		public InputManager Input => ArchaicGame.Input;
		public SceneManager Scenes => ArchaicGame.Scenes;

		public virtual void Initialize()
		{
			
		}

		public virtual void LoadContent(ContentManager content)
		{
			IsLoaded = true;
		}

		public virtual void Update(GameTime gameTime)
		{
			
		}

		public virtual void Draw(GameTime gameTime)
		{
			
		}
	}
}
