using System;
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

        public static Vector2 SetX(this Vector2 input, float x)
        {
            var ret = new Vector2(x, input.Y);
            return ret;
        }

        public static Vector2 SetY(this Vector2 input, float y)
        {
            var ret = new Vector2(input.X, y);
            return ret;
        }

        public static float DistanceTo(this Vector2 input, Vector2 otherPoint) => Vector2.Distance(input, otherPoint);
        public static float AngleTo(this Vector2 instance, Vector2 other) => (float)Math.Atan2(instance.Y - other.Y, instance.X - other.X);
        public static bool Near(this Vector2 instance, Vector2 other, float maxDistance) => instance.DistanceTo(other) <= maxDistance;

    }
}