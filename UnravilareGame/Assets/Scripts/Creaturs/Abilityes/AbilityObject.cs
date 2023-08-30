using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[Serializable]
public enum AbilityType
{
    Atack,
    Shield,
    Heal,
    Phantom
}


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

[CreateAssetMenu(fileName = "Ability", menuName = "Abilities")]
public class AbilityObject : ScriptableObject
{






    public static Ability CreateBlankData(AbilityType type)
    {
        switch (type)
        {
            case AbilityType.Atack: return new AtackAbility();
            case AbilityType.Shield: return new ShieldAbility();
            case AbilityType.Heal: return new HealAbility();
            case AbilityType.Phantom: return new PhantomAbility();
            default: return null;
        }
    }
    #region ABILITYES
    [Serializable]
    public class Ability
    {
        [SerializeField] int _iD;

        [SerializeField] float _actionTime;
        [SerializeField] float _distance;

        [SerializeField] float _level;
        [SerializeField] float _hp;
        [SerializeField] GameObject _object;

        public int ID { get => _iD; }
        public float actionTime { get => _actionTime; }
        public float distance { get => _distance; }
        public float level { get => _level; }
        public float hp { get => _hp; }
        public GameObject Object { get => _object; }
    }

    [Serializable]
    public class AtackAbility : Ability
    {
        [SerializeField] float _damage;
        [SerializeField] float _atackRange;
        public float damage { get => _damage;  }
        public float atackRange { get => _atackRange; }

        public AtackAbility()
        {
        }

    }

    [Serializable]
    public class ShieldAbility : Ability
    {
        [SerializeField] float _shieldRange;
        public float shieldRange { get => _shieldRange; }
        // public ShieldItem() {  }

    }
    [Serializable]
    public class HealAbility : Ability
    {
        [SerializeField] float _restoreHpPerSec;
        public float restoreHpPerSec { get => _restoreHpPerSec; }
        // public HealAbility()   {  }
    }
    [Serializable]
    public class PhantomAbility : Ability
    {
        //  public PhantomAbility(){}
    }


    public AbilityType type;
    [SerializeReference] public Ability ability;
    #endregion
}
