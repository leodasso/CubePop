using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTester : MonoBehaviour
{

	public float radius = 5;
	[Range(-1, 1)]
	public float xValue = .5f;

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, radius);
		Vector3 offset = new Vector3(xValue * radius, Arachnid.Math.PositionYOfCircle(radius, xValue), 0);
		Gizmos.DrawWireSphere(transform.position + offset, .05f);
	}
}
