using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationCurveExtension 
{
    public static float StartTime(this AnimationCurve curve)
    {
        if (curve.keys.Length < 1) return 0;
        return curve.keys[0].time;
    }

    public static float EndTime(this AnimationCurve curve)
    {
        if (curve.keys.Length < 1) return 0;
        return curve.keys[curve.keys.Length - 1].time;
    }

    /// <summary>
    /// The difference in time between the last point and the first point in the curve
    /// </summary>
    public static float Duration(this AnimationCurve curve)
    {
        return curve.EndTime() - curve.StartTime();
    }

}
