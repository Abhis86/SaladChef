using Framework.Scriptables;
using UnityEngine;

[System.Serializable]
public class Condition
{
    public enum Type
    {
        Bool,
        Int,
    }

    public enum Operator
    {
        IsEqual,
        GreaterThan,
        LessThan
    }

    [SerializeField] private Type m_Type = default;
    [SerializeField] private BoolProperty m_BoolProperty = default;
    [SerializeField] private bool m_Is = default;

    [SerializeField] private IntProperty m_IntProperty = default;
    [SerializeField] private Operator m_Operator = default;
    [SerializeField] private int m_IntToCompare = default;

    public bool Satisfy()
    {
        if (m_Type == Type.Bool)
            return m_BoolProperty.value == m_Is;
        if (m_Type == Type.Int)
        {
            if (m_Operator == Operator.IsEqual)
                return m_IntProperty.value == m_IntToCompare;
            if (m_Operator == Operator.GreaterThan)
                return m_IntProperty.value > m_IntToCompare;
            if (m_Operator == Operator.LessThan)
                return m_IntProperty.value < m_IntToCompare;
        }

        return false;
    }
}
