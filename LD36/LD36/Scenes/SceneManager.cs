using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LD36.Scenes
{
	public class SceneManager
	{
		private Dictionary<SceneNames, Scene> _scenes = new Dictionary<SceneNames, Scene>();

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

		public void AddScene(SceneNames name, Scene scene)
		{
			_scenes.Add(name, scene);
		}

		public void ChangeScene(SceneNames name)
		{
			var scene = _scenes[name];
			CurrentScene = scene;
			if(!CurrentScene.IsLoaded) CurrentScene.LoadContent(AdventureGame.ContentManager);
		}
	}
}
