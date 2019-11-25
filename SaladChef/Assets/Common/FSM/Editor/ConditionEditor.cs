
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Condition))]
public class ConditionEditor : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var gap = 5;  //Gap Between Properties

        int totalLine = 4;

        int enumValue = property.FindPropertyRelative("m_Type").intValue;

        switch (enumValue)
        {
            case 0: totalLine = 3; break;      //Bool has 3 properties;
            case 1: totalLine = 4; break;      //Int has 4 properties
        }

        return (EditorGUIUtility.singleLineHeight + gap) * totalLine + EditorGUIUtility.standardVerticalSpacing * (totalLine - 1);
    }


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var gap = 5;                                              //Gap Between Properties (Should be same as property height function)
        var height = EditorGUIUtility.singleLineHeight;           //Height of each property

        EditorGUI.BeginProperty(position, label, property);
        GUI.Box(position, GUIContent.none);

        Rect newposition = position;
        newposition.height = height;

        //Addiing initial Gap....
        newposition.y += gap;

        int enumValue = property.FindPropertyRelative("m_Type").intValue;
        EditorGUI.PropertyField(newposition, property.FindPropertyRelative("m_Type"));

        switch (enumValue)
        {
            case 0:
            {
                newposition.y += height + gap;
                EditorGUI.ObjectField(newposition, property.FindPropertyRelative("m_BoolProperty"));

                newposition.y += height + gap;
                EditorGUI.PropertyField(newposition, property.FindPropertyRelative("m_Is"));
                break;
            }

            case 1:
            {
                newposition.y += height + gap;
                EditorGUI.ObjectField(newposition, property.FindPropertyRelative("m_IntProperty"));

                newposition.y += height + gap;
                EditorGUI.PropertyField(newposition, property.FindPropertyRelative("m_Operator"));

                newposition.y += height + gap;
                EditorGUI.PropertyField(newposition, property.FindPropertyRelative("m_IntToCompare"));
                break;
            }
        }

        EditorGUI.EndProperty();

    }

}
