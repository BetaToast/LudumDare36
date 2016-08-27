using Microsoft.Xna.Framework;

namespace LD36.Extensions
{
	public static class ColorExtensions
	{
		public static Color Random(this Color color, float min = 0f, float max = 1f)
		{
			var rnd = ArchaicGame.Random;
			var r = rnd.Next(min, max);
			var g = rnd.Next(min, max);
			var b = rnd.Next(min, max);
			return new Color(new Vector3(r, g, b));
		}

		public static Color WithOpacity(this Color color, float opacity)
		{
			return new Color(color, opacity);
		}
	}
}