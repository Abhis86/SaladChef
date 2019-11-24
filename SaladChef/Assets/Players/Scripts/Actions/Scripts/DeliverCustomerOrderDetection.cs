using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/DeliverCustomerOrderDetection")]
    public class DeliverCustomerOrderDetection : ChefAction
    {
        public override void DoAction()
        {
        }

        public override void DoActionUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(m_Chef.pActionKeyCode))
            {
                Customer customer = GetCustomerWaitingForOrder();
                if (customer != null)
                {
                    m_Chef.isReadyToDeliverSalad.value = true;
                    m_Chef.pSelectedCustomeToDeliverSalad = customer.gameObject;
                    m_Chef.MoveToNextState();
                }
            }
        }

        private Customer GetCustomerWaitingForOrder()
        {
            RaycastHit2D hit = Physics2D.Raycast(m_ChefTransform.value.position, Vector2.zero);
            Table table = null;
            if (hit.collider != null)
                table = hit.collider.GetComponent<Table>();
            if (table != null && table.pCustomer != null /*&& table.pCustomer.pOrderedTakenByChef != null*/)
                return table.pCustomer;

            return null;
        }
    }
}
