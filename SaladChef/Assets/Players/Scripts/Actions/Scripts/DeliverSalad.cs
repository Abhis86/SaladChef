using Framework.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/DeliverSalad")]
    public class DeliverSalad : GameAction
    {
        public override void DoAction(Actor actor)
        {
            Chef chef = ((ChefActor)actor).chef;
            chef.isDeliveredCorrectSaladCombination.value = chef.pSelectedCustomeToDeliverSalad.GetComponent<Customer>().ReceiveSalad(chef, chef.pSaladPickedToDeliver);
            chef.pItemsHolder.ClearChildren();
            chef.pSaladPickedToDeliver.Clear();
            chef.MoveToNextState();
        }

        public override void DoActionUpdate(Actor actor,float deltaTime)
        {
        }
    }
}
