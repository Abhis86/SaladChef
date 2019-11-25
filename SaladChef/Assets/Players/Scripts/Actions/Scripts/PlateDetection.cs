using Framework.FSM;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/PlateDetection")]
    public class PlateDetection : GameAction
    {
        public override void DoAction(Actor actor)
        {
           
        }

        public override void DoActionUpdate(Actor actor,float deltaTime)
        {
            if (Input.GetKeyDown(((ChefActor)actor).chef.pActionKeyCode))
            {
                if (GetFreePlate(((ChefActor)actor).chefTransform.value) != null)
                {
                    ((ChefActor)actor).chef.isReadyToPickSalad.value = true;
                    ((ChefActor)actor).chef.MoveToNextState();
                }
            }
        }

        private Plate GetFreePlate(Transform chef)
        {
            RaycastHit2D hit = Physics2D.Raycast(chef.position, Vector2.zero);
            Plate plate = null;
            if (hit.collider != null)
            {
                plate = hit.collider.GetComponent<Plate>();
                if (plate == null || plate.pIsInUse)
                    plate = null;
            }
            return plate;
        }
    }
}
