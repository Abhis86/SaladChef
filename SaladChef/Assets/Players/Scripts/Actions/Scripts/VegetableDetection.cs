using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/VegetableDetection")]
    public class VegetableDetection : ChefAction
    {
        public override void DoAction()
        {
        }

        public override void DoActionUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(m_Chef.pActionKeyCode))
            {
                VegetableView vegetable = GetVegetable();
                if (vegetable)
                {
                    m_Chef.isReadyToCollectVegetables.value = true;
                    m_Chef.selectedVegetable = vegetable.gameObject;
                    m_Chef.MoveToNextState();
                }
            }
        }

        private VegetableView GetVegetable()
        {
            RaycastHit2D hit = Physics2D.Raycast(m_ChefTransform.value.position, Vector2.zero);
            VegetableView vegetable = null;
            if (hit.collider != null)
                vegetable = hit.collider.GetComponent<VegetableView>();

            return vegetable;
        }
    }
}
