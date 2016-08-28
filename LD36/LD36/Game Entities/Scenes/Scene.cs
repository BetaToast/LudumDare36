using System.Collections.Generic;
using LD36.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LD36.Game_Entities.Scenes
{
    public abstract class Scene
    {
        protected SpriteBatch SpriteBatch => ArchaicGame.SpriteBatch;
        protected TextureManager Textures => ArchaicGame.Textures;
        protected SoundManager Sounds => ArchaicGame.Sounds;
        protected SongManager Songs => ArchaicGame.Songs;
        protected InputManager Input => ArchaicGame.Input;
        protected SceneManager Scenes => ArchaicGame.Scenes;
        protected FontManager Fonts => ArchaicGame.Fonts;

		public bool ContentLoaded { get; protected set; }
		public List<BaseGameEntity> Entities { get; set; }

	    protected Scene()
	    {
		    Entities = new List<BaseGameEntity>();
	    }
		
        public abstract void Load(ContentManager content);
        public abstract void UnLoad();

		public virtual void Initialize() { }
		public virtual void Update(GameTime gameTime) { }
		public virtual void Draw(GameTime gameTime) { }
	}
}
