using System;
using UnityEngine;

namespace Extensions
{
    public static class VectorExtensions
    {
        public static bool HasMovementAtAnyAxis(this Vector2 movement)
        {
            return !movement.IsCloseTo(new Vector2(0, 0));
        }

        public static bool IsCloseTo(this Vector2 current, Vector2 other)
        {
            var subtract = current - other;
            return Math.Abs(subtract.x) <= float.Epsilon
                   && Math.Abs(subtract.y) <= float.Epsilon;
        }

        public static float Length(this Vector3 vector3)
        {
            var x = vector3.x;
            var y = vector3.y;
            var z = vector3.z;

            return (float) Math.Sqrt(x * x + y * y + z * z);
        }
    }
}
