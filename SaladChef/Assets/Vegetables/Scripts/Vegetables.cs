using Framework.Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Vegetables")]
    public class Vegetables : ScriptableObject
    {
        [SerializeField] GameObject m_Template = default;
        [SerializeField] private Vegetable[] m_Vegetables = default;

        public Vegetable[] pVegetables { get => m_Vegetables;}

        public void Create()
        {
            for(int i =0; i < m_Vegetables.Length; ++i)
            {
                GameObject vegetable = Instantiate(m_Template);
                vegetable.name = m_Vegetables[i].pName;
                vegetable.GetComponent<SpriteRenderer>().sprite = m_Vegetables[i].pSprite;
                vegetable.GetComponent<VegetableView>().vegetable = m_Vegetables[i];
                vegetable.transform.SetParent(m_Vegetables[i].pContainer.value);
            }
        }
    }
}
