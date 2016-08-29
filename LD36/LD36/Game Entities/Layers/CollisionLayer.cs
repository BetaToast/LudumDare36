using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD36.Game_Entities.Layers
{
	public class CollisionLayer
	{
		private readonly Texture2D _texture;
		private readonly Color[,] _pixels;
		private readonly Vector4 _colorKey = new Vector4(0, 0, 0, 0);

		public CollisionLayer(Texture2D texture)
		{
			_texture = texture;
			var data = new Color[_texture.Width * _texture.Height];
			_texture.GetData(data);
			_pixels = new Color[_texture.Width, _texture.Height];
			for (var x = 0; x < _texture.Width; x++)
			{
				for (var y = 0; y < _texture.Height; y++)
				{
					var pixel = data[x + y * _texture.Width];
					_pixels[x, y] = pixel;
				}
			}
		}

		public bool IsValidClick()
		{
			var mx = (int)ArchaicGame.Input.Mouse.CurrentPosition.X;
			var my = (int)ArchaicGame.Input.Mouse.CurrentPosition.Y;

			if (mx < 0 || my < 0 || mx > _pixels.GetUpperBound(0) || my > _pixels.GetUpperBound(1)) return false;

			var pixel = _pixels[mx, my];
			return pixel.A == 0;
		}

		public bool IsValidLocation(int x, int y)
		{
			if (x < 0 || y < 0 || x > _pixels.GetUpperBound(0) || y > _pixels.GetUpperBound(1)) return false;
			var pixel = _pixels[x, y];
			return pixel.A == 0;
		}

		public bool Intersects(Rectangle bounds)
		{
			for (var x = bounds.Left; x < bounds.Right; x++)
			{
				for (var y = bounds.Top; y < bounds.Bottom; y++)
				{
					if (x >= _pixels.GetUpperBound(0) || y >= _pixels.GetUpperBound(1)) return true;
					var pixel = _pixels[x, y];
					if (pixel.ToVector4() != _colorKey) return true;
				}
			}
			return false;
		}
	}
}