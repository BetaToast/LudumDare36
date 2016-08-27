using LD36.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD36.Characters
{
	public class Player
	{
		private Texture2D _texture;

		private SpriteBatch _spriteBatch => ArchaicGame.SpriteBatch;

		public Vector2 Position { get; set; }
		public Vector2 Size { get; set; }
		public Color Tint { get; set; }
		public Vector2 Destination { get; set; }
		public float Speed { get; set; }

		public int X => (int) Position.X;
		public int Y => (int) Position.Y;
		public int Width => (int) Size.X;
		public int Height => (int) Size.Y;
		public Rectangle Bounds => new Rectangle(X, Y, Width, Height);

		public Player(Texture2D texture, int x = 0, int y  = 0, int width = 32, int height = 32)
		{
			_texture = texture;
			Position = new Vector2(x, y);
			Size = new Vector2(width, height);
			Tint = Color.White;
			Destination = Vector2.Zero.MinValue();
			Speed = 3f;
		}

		public void Update(GameTime gameTime)
		{
			if (Destination != Vector2.Zero.MinValue())
			{
				var dx = Destination.X > Position.X ? 1 : -1;
				var dy = Destination.Y > Position.Y ? 1 : -1;
				Position = Position.Add(dx * Speed, dy * Speed);
				if ((int)Position.X == (int)Destination.X && (int)Position.Y == (int)Destination.Y)
				{
					Destination = Vector2.Zero.MinValue();
				}
			}
		}

		public void Draw(GameTime gameTime)
		{
			_spriteBatch.Draw(_texture, Bounds, Tint);
		}
	}
}