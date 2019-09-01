using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arachnid
{

	[CreateAssetMenu(menuName ="Arachnid/Int Value")]
	public class IntValue : ScriptableObject
	{
		[ToggleLeft]
		public bool readOnly;
		[SerializeField, ShowInInspector]
		int myValue;
        
		public int Value
		{
			get { return myValue; }
			set {
				// If the value is changing, raise the onValueChange events
				if (value != myValue)
				{
					if (readOnly)
					{
						Debug.LogWarning(name + " value can't be set because it's readonly.", this);
						return;
					}
					myValue = value;
					foreach (var e in onValueChange) e.Raise();
				}
			}
		}

		[AssetsOnly]
		public List<GameEvent> onValueChange;
		[MultiLineProperty(5)]
		public string comments;

		/// <summary>
		/// Increases the value by the given amount
		/// </summary>
		public void IterateValue (int amount)
		{
			Value += amount;
		}

		/// <summary>
		/// Resets the value back to zero.
		/// </summary>
		public void ResetValue()
		{
			Value = 0;
		}
	}
}