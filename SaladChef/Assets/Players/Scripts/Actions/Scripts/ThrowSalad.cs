using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/ThrowSalad")]
    public class ThrowSalad : ChefAction
    {
        public override void DoAction()
        {
            m_Chef.pSalad.Clear();
            m_Chef.pItemsHolder.ClearChildren();
            m_Chef.MoveToNextState();
        }

        public override void DoActionUpdate(float deltaTime)
        {
        }

      
    }
}
