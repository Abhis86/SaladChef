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
                CreateVegetable(m_Vegetables[i], m_Vegetables[i].pContainer.value);
        }

        public GameObject CreateVegetable(Vegetable vegetable, Transform parent)
        {
            GameObject vegetableObject = Instantiate(m_Template);
            vegetableObject.name = vegetable.pName;
            vegetableObject.GetComponent<SpriteRenderer>().sprite = vegetable.pSprite;
            vegetableObject.GetComponent<VegetableView>().vegetable = vegetable;
            vegetableObject.transform.SetParent(parent);
            return vegetableObject;
        }
    }
}
