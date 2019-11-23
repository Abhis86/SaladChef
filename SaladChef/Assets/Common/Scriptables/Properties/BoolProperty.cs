using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Scriptables
{
    public interface ICondition { }
    [CreateAssetMenu(menuName = "Properties/Bool")]
    public class BoolProperty : ScriptableObject
    {
        [SerializeField] private bool m_IsSerializable = true;
        public bool value;

        private void OnEnable()
        {
            if (!m_IsSerializable)
                value = default;
        }

        private void OnDisable()
        {
            if (!m_IsSerializable)
                value = default;
        }

        public void Set(bool v)
        {
            value = v;
        }

        public void Set(BoolProperty v)
        {
            value = v.value;
        }

        public void Reverse()
        {
            value = !value;
        }

        public bool Compare(bool v)
        {
            return v == value;
        }

        public bool Compare(BoolProperty v)
        {
            return value == v.value;
        }

    }
}
