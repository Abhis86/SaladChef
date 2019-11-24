using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/TakeCustomerOrder")]
    public class TakeCustomerOrder : ChefAction
    {
        public override void DoAction()
        {
        }

        public override void DoActionUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(m_Chef.pActionKeyCode))
            {
                Customer customer = GetCustomerWaitingToOrder();
                if (customer != null)
                {
                    customer.pOrderedTakenByChef = m_Chef;
                    m_Chef.MoveToNextState();
                }
            }
        }

        private Customer GetCustomerWaitingToOrder()
        {
            RaycastHit2D hit = Physics2D.Raycast(m_ChefTransform.value.position, Vector2.zero);
            Table table = null;
            if (hit.collider != null)
                table = hit.collider.GetComponent<Table>();
            if (table != null && table.pCustomer != null && table.pCustomer.pOrderedTakenByChef == null)
                return table.pCustomer;

            return null;
        }
    }
}
