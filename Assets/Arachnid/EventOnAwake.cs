using System.Collections;
using System.Collections.Generic;
using Arachnid;
using UnityEngine;
using UnityEngine.Events;

public class EventOnAwake : MonoBehaviour
{
	public UnityEvent eventToInvoke;
	public List<GameEvent> gameEvents = new List<GameEvent>();
	
	void Awake()
	{
		eventToInvoke.Invoke();
		foreach (var e in gameEvents) e.Raise();
	}
}