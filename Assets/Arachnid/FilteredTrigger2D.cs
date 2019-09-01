using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arachnid
{
	[RequireComponent(typeof(Collider2D))]
	public class FilteredTrigger2D : MonoBehaviour
	{

		[ToggleLeft, Tooltip("Will only trigger once.")]
		public bool oneOff;

		[ToggleLeft, Tooltip("Only allow triggers from objects of a particular collection")]
		public bool filterTriggers = true;

		[ShowIf("filterTriggers"), Tooltip("Any object in one of these collections can trigger this."), AssetsOnly]
		public List<Collection> triggerers = new List<Collection>();

		bool _triggered;


		void OnTriggerEnter2D(Collider2D other)
		{
			if (!filterTriggers)
			{
				Trigger(other);
				return;
			}

			foreach (var c in triggerers)
			{
				if (c.ContainsGameObject(other.gameObject))
				{
					Trigger(other);
					return;
				}
			}
		}

		void Trigger(Collider2D other)
		{
			if (_triggered && oneOff) return;
			_triggered = true;
			OnTriggered(other);
		}

		protected virtual void OnTriggered(Collider2D triggerer)
		{
		}
	}
}