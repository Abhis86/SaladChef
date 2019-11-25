using Framework.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/ThrowSalad")]
    public class ThrowSalad : GameAction
    {
        public override void DoAction(Actor actor)
        {
            ((ChefActor)actor).chef.pSaladPickedToDeliver.Clear();
            ((ChefActor)actor).chef.pItemsHolder.ClearChildren();
            ((ChefActor)actor).chef.MoveToNextState();
        }

        public override void DoActionUpdate(Actor actor,float deltaTime)
        {
        }

      
    }
}
