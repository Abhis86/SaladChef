using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/EnableDisableMovemenControl")]
    public class EnableMovementControl : ChefAction
    {
        [SerializeField] private bool m_EnableMovementControl = default;

        public override void DoAction()
        {
            m_ChefTransform.value.GetComponent<MovementController>().enabled = m_EnableMovementControl;
        }

        public override void DoActionUpdate(float deltaTime)
        {
        }
    }
}
