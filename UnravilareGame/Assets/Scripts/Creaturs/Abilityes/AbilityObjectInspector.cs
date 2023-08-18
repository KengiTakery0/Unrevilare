using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(AbilityObject))]

public class AbilityObjectInspector : Editor
{
    SerializedProperty m_type;
    SerializedProperty m_abilityInfo;

    private void OnEnable()
    {
        m_type = serializedObject.FindProperty("type");
        m_abilityInfo = serializedObject.FindProperty("abilityInfo");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(m_type);
        if (EditorGUI.EndChangeCheck())
        {
            m_abilityInfo.managedReferenceValue =
                    AbilityObject.CreateBlankData((AbilityType)m_type.intValue);
        }

        DrawPropertiesExcluding(serializedObject, new string[] { "type", "m_Script" });
        serializedObject.ApplyModifiedProperties();
    }
}
#endif


