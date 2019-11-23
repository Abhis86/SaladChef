using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/CollectVegetables")]
    public class CollectVegetables : ChefAction
    {
        public override void DoAction()
        {
            m_Chef.CollectVegetable();
            m_Chef.MoveToNextState();
        }

        public override void DoActionUpdate(float deltaTime)
        {
        }                     
    }
}
