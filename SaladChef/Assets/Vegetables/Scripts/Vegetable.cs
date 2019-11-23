using Framework.FSM;
using Framework.Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Vegetables/Vegetable")]
    public class Vegetable : ScriptableObject
    {
        [SerializeField] private string m_Name = default;
        [SerializeField] private Sprite m_Sprite = default;
        [SerializeField] private TransformProperty m_Container = default;

        public string pName { get => m_Name; }
        public Sprite pSprite { get => m_Sprite; }
        public TransformProperty pContainer { get => m_Container; }
    }
}
