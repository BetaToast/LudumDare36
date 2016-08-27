using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LD36.Scenes
{
	public class SceneManager
	{
		private Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();

		public Scene CurrentScene { get; set; }

		public SceneManager()
		{
			
		}

		public void Update(GameTime gameTime)
		{
			CurrentScene?.Update(gameTime);
		}

		public void Draw(GameTime gameTime)
		{
			CurrentScene?.Draw(gameTime);
		}

		public void AddScene(string name, Scene scene)
		{
			_scenes.Add(name, scene);
		}

		public void ChangeScene(string name)
		{
			var scene = _scenes[name];
			CurrentScene = scene;
			if(!CurrentScene.IsLoaded) CurrentScene.LoadContent(AdventureGame.ContentManager);
		}
	}
}
