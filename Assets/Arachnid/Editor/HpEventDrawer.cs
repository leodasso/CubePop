using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Arachnid;

[CustomPropertyDrawer(typeof(HpEvent))]
public class HpEventDrawer : PropertyDrawer
{
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty hpComparison = property.FindPropertyRelative("hpComparison");
        SerializedProperty hpPercentage = property.FindPropertyRelative("hpPercentage");
        SerializedProperty gameEvent = property.FindPropertyRelative("gameEvent");

        var eventRect = new Rect(position.position, new Vector2(position.width / 3, position.height));
        var labelRect = new Rect(eventRect.x + eventRect.width, position.y, 64, position.height);
        var enumRect = new Rect(labelRect.position.x + labelRect.width, position.y, 50, position.height);

        float w = enumRect.position.x + enumRect.width;
        var sliderRect = new Rect(w + 2, position.y, position.width - w + 32, position.height);

        EditorGUI.PropertyField(eventRect, gameEvent, new GUIContent(""));
        EditorGUI.LabelField(labelRect, new GUIContent("when HP%"));
        EditorGUI.PropertyField(enumRect, hpComparison, new GUIContent(""));
        EditorGUI.Slider(sliderRect,  hpPercentage, 0, 1, new GUIContent(""));

        EditorGUI.EndProperty();
    }

}
