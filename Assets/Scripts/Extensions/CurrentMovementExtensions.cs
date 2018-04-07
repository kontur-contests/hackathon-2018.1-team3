using System;
using Assets.Scripts.Models;

namespace Assets.Scripts.Extensions
{
    public static class CurrentMovementExtensions
    {
        private static float Epsilon = 0.0005f;

        public static bool HasMovementAtAnyAxis(this CurrentMovement movement)
        {
            return Math.Abs(movement.XAxisMovement) > Epsilon
                   || Math.Abs(movement.YAxisMovement) > Epsilon;
        }
    }
}
