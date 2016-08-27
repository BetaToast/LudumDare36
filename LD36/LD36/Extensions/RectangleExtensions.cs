using Microsoft.Xna.Framework;

namespace LD36.Extensions
{
	public static class RectangleExtensions
	{
		public static Rectangle Translate(this Rectangle rect, int x, int y)
		{
			var ret = new Rectangle(rect.X + x, rect.Y + y, rect.Width, rect.Height);
			return ret;
		}
	}
}