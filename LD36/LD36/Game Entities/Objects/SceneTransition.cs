using System;
using LD36.Extensions;
using Microsoft.Xna.Framework;

namespace LD36.Game_Entities.Objects
{
	public sealed class SceneTransition
		: BaseGameEntity
	{
		public string DestinationSceneName { get; set; }
		public Action OnTransition { get; set; }

		public SceneTransition(Vector2 position, Vector2 size, string destinationSceneName)
		{
			Texture = ArchaicGame.Textures[TextureNames.WhitePixel];
			Position = position;
			Size = size;
			Tint = Color.Red.WithOpacity(0.5f);
			DestinationSceneName = destinationSceneName;
		}

		public override void Update(GameTime gameTime)
		{
			if (ArchaicGame.Player.Bounds.Intersects(Bounds))
			{
				OnTransition?.Invoke();
				ArchaicGame.Scenes.ChangeScene(DestinationSceneName);
			}

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			if (!ArchaicGame.IsDebug) return;
			base.Draw(gameTime);
		}
	}
}