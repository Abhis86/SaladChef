using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Scriptables
{
    [CreateAssetMenu(menuName = "Properties/Integer")]
    public class IntProperty : ScriptableObject
    {
        [SerializeField] private bool m_IsSerializable = true;
        public int value;

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

        public void Set(int v)
        {
            value = v;
        }

        public void Set(IntProperty v)
        {
            IntProperty i = (IntProperty)v;
            value = i.value;
        }

        public void Add(int v)
        {
            value += v;
        }

        public void Add(IntProperty v)
        {
            IntProperty i = (IntProperty)v;
            value += i.value;
        }
    }
}
