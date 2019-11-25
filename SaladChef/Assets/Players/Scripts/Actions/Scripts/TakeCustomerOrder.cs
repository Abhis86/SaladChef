using Framework.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/TakeCustomerOrder")]
    public class TakeCustomerOrder : GameAction
    {
        public override void DoAction(Actor actor)
        {
        }

        public override void DoActionUpdate(Actor actor, float deltaTime)
        {
            if (Input.GetKeyDown(((ChefActor)actor).chef.pActionKeyCode))
            {
                Customer customer = GetCustomerWaitingToOrder(((ChefActor)actor).chefTransform.value);
                if (customer != null)
                {
                    customer.pOrderedTakenByChef = ((ChefActor)actor).chef;
                    ((ChefActor)actor).chef.MoveToNextState();
                }
            }
        }

        private Customer GetCustomerWaitingToOrder(Transform chef)
        {
            RaycastHit2D hit = Physics2D.Raycast(chef.position, Vector2.zero);
            Table table = null;
            if (hit.collider != null)
                table = hit.collider.GetComponent<Table>();
            if (table != null && table.pCustomer != null && table.pCustomer.pOrderedTakenByChef == null)
                return table.pCustomer;

            return null;
        }
    }
}
