using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/DeliverSalad")]
    public class DeliverSalad : ChefAction
    {
        public override void DoAction()
        {
            m_Chef.isDeliveredCorrectSaladCombination.value = m_Chef.pSelectedCustomeToDeliverSalad.GetComponent<Customer>().ReceiveSalad(m_Chef, m_Chef.pSalad);
            m_Chef.pItemsHolder.ClearChildren();
            m_Chef.pSalad.Clear();
            m_Chef.MoveToNextState();
        }

        public override void DoActionUpdate(float deltaTime)
        {
        }
    }
}
