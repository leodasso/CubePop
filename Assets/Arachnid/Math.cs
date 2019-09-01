using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arachnid
{
	public static class Math
	{
		/// <summary>
		/// Returns the positive position of the y coordinate of a circle given the circle's radius and x position.
		/// </summary>
		/// <param name="radius">Circle's radius in real units</param>
		/// <param name="x">The x position on the circle, where 0 is the origin, and 1 is the farthest right on the circle</param>
		public static float PositionYOfCircle(float radius, float x)
		{
			return Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(radius * x, 2));
		}

		/// <summary>
		/// Returns the euler angle of the given vector.
		/// </summary>
		/// <param name="degreesOffset">Degrees to offset the result by</param>
		public static float AngleFromVector2(Vector2 vector, float degreesOffset)
		{
			Vector2 rotatedVector = Quaternion.Euler(0, 0, degreesOffset) * vector;
			float rad = Mathf.Atan2(rotatedVector.y, rotatedVector.x);
			return Mathf.Rad2Deg * rad;
		}
	}
}