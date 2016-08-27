using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LD36.Scenes
{
	public class Scene
	{
		public bool IsLoaded { get; set; }

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
