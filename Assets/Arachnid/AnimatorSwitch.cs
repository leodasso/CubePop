using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

/// <summary>
/// Attach to a GO with an animator, and this allows for animator 'bool' parameters to be set from Unity Events.
/// </summary>
[RequireComponent(typeof(Animator))]
[TypeInfoBox("Attach to a GO with an Animator, and this allows for animator 'bool' parameters to be set from Unity Events.")]
public class AnimatorSwitch : MonoBehaviour
{
	Animator _animator;

	// Use this for initialization
	void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	/* The functions below are intentionally kept to 1 parameter,
	 because that way they can be accessed by Unity Events.
	 */
	
	public void SetBoolTrue(string parameterName)
	{
		_animator.SetBool(parameterName, true);
	}

	public void SetBoolFalse(string parameterName)
	{
		_animator.SetBool(parameterName, false);
	}
}