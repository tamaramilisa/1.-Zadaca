using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public class CollisionDetector
    {
        /// <summary>
        /// Calculates if rectangles describing two sprites
        /// are overlapping on screen.
        /// </summary>
        /// <param name="s1">First sprite</param>
        /// <param name="s2">Second sprite</param>
        /// <returns>Returns true if overlapping</returns>
        public static bool Overlaps(Sprite s1, Sprite s2)
        {
            // Console.WriteLine(s1.Position.ToString() + "" + s1.Size.ToString()+"@@@@@");
            //  Console.WriteLine(s2.Position.ToString() + "" + s2.Size.ToString());
            // clamp(value, min, max) - limits value to the range min..max

            // Find the closest point to the circle within the rectangle
            float closestX = MathHelper.Clamp(s1.Position.X, s2.Position.X, s2.Position.X + s2.Size.Width);
            float closestY = MathHelper.Clamp(s1.Position.Y, s2.Position.Y, s2.Position.Y - s2.Size.Height);

            // Calculate the distance between the circle's center and this closest point
            float distanceX = s1.Position.X - closestX;
            float distanceY = s1.Position.Y - closestY;

            // If the distance is less than the circle's radius, an intersection occurs
            float distanceSquared = (distanceX * distanceX) + (distanceY * distanceY);
            return distanceSquared < (s1.Size.Width * 1.0 / 2 * s1.Size.Width * 1.0 / 2);
        }
    }
}
