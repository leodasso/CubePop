using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

#if UNITY_EDITOR

using Sirenix.OdinInspector.Editor;
using UnityEditor;
using Sirenix.Utilities;

#endif

namespace Arachnid
{

	[System.Serializable]
	public class IntReference
	{
		public PropertyType useConstant = PropertyType.Local;
		public int constantValue;
		[AssetsOnly]
		public IntValue valueObject;

        
		public int Value
		{
			get { return useConstant == PropertyType.Local ? constantValue : valueObject.Value; }

			set {
				if ( useConstant == PropertyType.Global) valueObject.Value = value;
				else constantValue = value;
			}
		}
	}
    
#if UNITY_EDITOR

	[OdinDrawer]
	public class IntRefDrawer : OdinValueDrawer<IntReference>
	{
		protected override void DrawPropertyLayout(IPropertyValueEntry<IntReference> entry, GUIContent label)
		{
			IntReference value = entry.SmartValue;

			var rect = EditorGUILayout.GetControlRect();

			// In Odin, labels are optional and can be null, so we have to account for that.
			if (label != null)
			{
				rect = EditorGUI.PrefixLabel(rect, label);
			}

			var prev = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth = 0;

			value.useConstant = (PropertyType)EditorGUI.EnumPopup(rect.AlignLeft(rect.width * 0.4f), "", value.useConstant);

			Rect rightRect = rect.AlignRight(rect.width * 0.6f);

			if (value.useConstant == PropertyType.Global)
			{
				value.valueObject =
					(IntValue) EditorGUI.ObjectField(rightRect, "", value.valueObject, typeof(IntValue), false);
			}
			else
			{
				value.constantValue = EditorGUI.IntField(rightRect, value.constantValue);
			}

			EditorGUIUtility.labelWidth = prev;
			entry.SmartValue = value;
		}
	}

#endif
}