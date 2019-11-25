using Framework.FSM;
using Framework.Scriptables;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/ChoppingBoardDetection")]
    public class ChoppingBoardDetection : GameAction
    {
        public override void DoAction(Actor actor)
        {
        }

        public override void DoActionUpdate(Actor actor,float deltaTime)
        {
            if (Input.GetKeyDown(((ChefActor)actor).chef.pActionKeyCode))
            {
                ChoppingBoard board = GetFreeChoppingBoard(((ChefActor)actor).chefTransform.value);

                if (board)
                {

                    ((ChefActor)actor).chef.isReadyToChopVegetables.value = true;
                    ((ChefActor)actor).chef.pUsingChoppingBoard = board.transform;
                    ((ChefActor)actor).chef.MoveToNextState();
                }
            }
        }

        private ChoppingBoard GetFreeChoppingBoard(Transform chef)
        {
            RaycastHit2D hit = Physics2D.Raycast(chef.position, Vector2.zero);
            ChoppingBoard board = null;
            if (hit.collider != null)
            {
                board = hit.collider.GetComponent<ChoppingBoard>();
                if (board == null || board.pIsInUse)
                    board = null;
            }
            return board;
        }
    }
}
