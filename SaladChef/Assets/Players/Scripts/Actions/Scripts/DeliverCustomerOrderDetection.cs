using Framework.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/DeliverCustomerOrderDetection")]
    public class DeliverCustomerOrderDetection : GameAction
    {
        public override void DoAction(Actor actor)
        {
        }

        public override void DoActionUpdate(Actor actor, float deltaTime)
        {
            if (Input.GetKeyDown(((ChefActor)actor).chef.pActionKeyCode))
            {
                Customer customer = GetCustomerWaitingForOrder(((ChefActor)actor).chefTransform.value);
                if (customer != null)
                {
                    ((ChefActor)actor).chef.isReadyToDeliverSalad.value = true;
                    ((ChefActor)actor).chef.pSelectedCustomeToDeliverSalad = customer.gameObject;
                    ((ChefActor)actor).chef.MoveToNextState();
                }
            }
        }

        private Customer GetCustomerWaitingForOrder(Transform chef)
        {
            RaycastHit2D hit = Physics2D.Raycast(chef.position, Vector2.zero);
            Table table = null;
            if (hit.collider != null)
                table = hit.collider.GetComponent<Table>();
            if (table != null && table.pCustomer != null /*&& table.pCustomer.pOrderedTakenByChef != null*/)
                return table.pCustomer;

            return null;
        }
    }
}
