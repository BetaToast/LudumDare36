using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LD36.Game_Entities.Scenes
{
	public class SceneManager
	{
		private readonly Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();

		public Scene CurrentScene { get; set; }
		
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
            ArchaicGame.Input.Reset();
            CurrentScene?.UnLoad();

            var scene = _scenes[name];
            scene.Load(ArchaicGame.ContentManager);

            //if (!CurrentScene.IsLoaded)
            //    CurrentScene.LoadContent(ArchaicGame.ContentManager);

            CurrentScene = scene;
        }
    }
}
