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

		[MultiLineProperty()]
		public string description;

		public float ValueFor(float xAxisInput)
		{
			return curve.Evaluate(xAxisInput) * multiplier;
		}
	}
}