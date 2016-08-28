using Microsoft.Xna.Framework;

namespace LD36.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 MinValue(this Vector2 input)
        {
            return new Vector2(float.MinValue, float.MinValue);
        }

        public static Vector2 Add(this Vector2 input, float x, float y)
        {
            var ret = new Vector2(input.X + x, input.Y + y);
            return ret;
        }

        public static Point ToPoint(this Vector2 input) => new Point((int)input.X, (int)input.Y);
    }
}