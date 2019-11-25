using Framework.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/EnableDisableMovemenControl")]
    public class EnableMovementControl : GameAction
    {
        [SerializeField] private bool m_EnableMovementControl = default;

        public override void DoAction(Actor actor)
        {
            ((ChefActor)actor).chefTransform.value.GetComponent<MovementController>().enabled = m_EnableMovementControl;
        }

        public override void DoActionUpdate(Actor actor, float deltaTime)
        {
        }
    }
}
