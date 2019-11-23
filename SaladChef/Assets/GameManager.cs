using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Vegetables m_Vegetables = default;
        // Start is called before the first frame update
        void Start()
        {
            m_Vegetables.Create();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
