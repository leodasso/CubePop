using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arachnid
{
	[CreateAssetMenu(menuName = "Arachnid/Curve Object")]
	public class CurveObject : ScriptableObject
	{
		public float multiplier = 1;
		public AnimationCurve curve;

		public enum CurveMode
		{
			Clamp,
			Loop
		}

		[Tooltip("When retrieving the output (y-axis) for an input (x-axis), should it assume the curve loops or clamps?")]
		public CurveMode curveMode = CurveMode.Clamp;

		[MultiLineProperty()]
		public string description;

		public float ValueFor(float xAxisInput)
		{
			float processedX = xAxisInput;
			if (curveMode == CurveMode.Loop)
			{
				float remainder = xAxisInput % curve.Duration();
				processedX = curve.StartTime() + remainder;
			}
			
			return curve.Evaluate(processedX) * multiplier;
		}
	}
}