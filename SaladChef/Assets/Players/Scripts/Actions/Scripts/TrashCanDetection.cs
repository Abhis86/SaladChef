using Framework.FSM;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/TrashCanDetection")]
    public class TrashCanDetection : GameAction
    {
        public override void DoAction(Actor actor)
        {
           
        }

        public override void DoActionUpdate(Actor actor,float deltaTime)
        {
            if (Input.GetKeyDown(((ChefActor)actor).chef.pActionKeyCode))
            {
                if (GetFreeTrashCan(((ChefActor)actor).chefTransform.value) != null)
                {
                    ((ChefActor)actor).chef.isReadyToThrowSalad.value = true;
                    ((ChefActor)actor).chef.MoveToNextState();
                }
            }
        }

        private TrashCan GetFreeTrashCan(Transform chef)
        {
            RaycastHit2D hit = Physics2D.Raycast(chef.position, Vector2.zero);
            TrashCan trashCan = null;
            if (hit.collider != null)
            {
                trashCan = hit.collider.GetComponent<TrashCan>();
                if (trashCan == null || trashCan.pIsInUse)
                    trashCan = null;
            }
            return trashCan;
        }
    }
}
