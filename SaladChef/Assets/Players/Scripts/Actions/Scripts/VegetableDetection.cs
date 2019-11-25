using Framework.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/VegetableDetection")]
    public class VegetableDetection : GameAction
    {
        public override void DoAction(Actor actor)
        {
        }

        public override void DoActionUpdate(Actor actor,float deltaTime)
        {
            if (Input.GetKeyDown(((ChefActor)actor).chef.pActionKeyCode))
            {
                VegetableView vegetable = GetVegetable(((ChefActor)actor).chefTransform.value);
                if (vegetable)
                {
                    ((ChefActor)actor).chef.isReadyToCollectVegetables.value = true;
                    ((ChefActor)actor).chef.selectedVegetable = vegetable.gameObject;
                    ((ChefActor)actor).chef.MoveToNextState();
                }
            }
        }

        private VegetableView GetVegetable(Transform chef)
        {
            RaycastHit2D hit = Physics2D.Raycast(chef.position, Vector2.zero);
            VegetableView vegetable = null;
            if (hit.collider != null)
                vegetable = hit.collider.GetComponent<VegetableView>();

            return vegetable;
        }
    }
}
