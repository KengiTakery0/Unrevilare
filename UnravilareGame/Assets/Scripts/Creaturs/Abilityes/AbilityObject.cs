using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="Ability",menuName ="Abilities")]
public class AbilityObject : ScriptableObject
{
#if UNITY_EDITOR
    [CustomEditor(typeof(AbilityObject))]

    public class AbilityObjectInspector : Editor
    {
        SerializedProperty m_type;
        SerializedProperty m_ability;

        private void OnEnable()
        {
            m_type = serializedObject.FindProperty("type");
            m_ability = serializedObject.FindProperty("ability");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(m_type);
            if (EditorGUI.EndChangeCheck())
            {
                m_ability.managedReferenceValue =
                        AbilityObject.CreateBlankData((AbilityType)m_type.intValue);
            }

            DrawPropertiesExcluding(serializedObject, new string[] { "type", "m_Script" });
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
    [System.Serializable]
    public enum AbilityType
    {
        Shield,
        Atack,
        Heal,
        Phantom
    }

    // Determines how to create an Item from each ItemType
    public static Ability CreateBlankData(AbilityType type)
    {
        switch (type)
        {
            case AbilityType.Shield: return new ShieldItem();
            case AbilityType.Atack: return new AtackAbility();
            case AbilityType.Heal: return new HealAbility();
            case AbilityType.Phantom: return new PhantoAbility();
            default: return null;
        }
    }
    #region ABILITYES
    [System.Serializable]
    public class Ability
    {
        [SerializeField] int _iD;
        [SerializeField] float _actionTime;
        [SerializeField] float _distance;

        public void Use()
        {
            throw new NotImplementedException();
        }
    }

    [System.Serializable]
    public class AtackAbility : Ability
    {
        [SerializeField] int _damage;

        public AtackAbility()
        {

        }
    }

    [System.Serializable]
    public class ShieldItem : Ability
    {

        public ShieldItem()
        {

        }

    }
    public class HealAbility : Ability
    {
        public HealAbility()
        {

        }
    }
    public class PhantoAbility : Ability
    {
        public PhantoAbility()
        {

        }
    }


    public AbilityType type;
    [SerializeReference] public Ability ability;
    #endregion
}
