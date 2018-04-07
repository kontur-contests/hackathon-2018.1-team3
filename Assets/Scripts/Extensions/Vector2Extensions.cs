using System;
using UnityEngine;

namespace Extensions
{
    public static class Vector2Extensions
    {
        private static float Epsilon = 0.0005f;

        public static bool HasMovementAtAnyAxis(this Vector2 movement)
        {
            return Math.Abs(movement.x) > Epsilon
                   || Math.Abs(movement.y) > Epsilon;
        }
    }
}
