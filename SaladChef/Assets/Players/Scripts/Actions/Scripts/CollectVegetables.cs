﻿using Framework.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/CollectVegetables")]
    public class CollectVegetables : GameAction
    {
        public override void DoAction(Actor actor)
        {
            ((ChefActor)actor).chef.CollectVegetable();
            ((ChefActor)actor).chef.MoveToNextState();
        }

        public override void DoActionUpdate(Actor actor, float deltaTime)
        {
        }                     
    }
}
