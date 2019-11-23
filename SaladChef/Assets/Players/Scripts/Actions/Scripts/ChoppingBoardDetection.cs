using Framework.FSM;
using Framework.Scriptables;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/ChoppingBoardDetection")]
    public class ChoppingBoardDetection : ChefAction
    {
        public override void DoAction()
        {
        }

        public override void DoActionUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(m_Chef.pActionKeyCode))
            {
                ChoppingBoard board = GetFreeChoppingBoard();
                if (board)
                {
                    m_Chef.isReadyToChopVegetables.value = true;
                    m_Chef.pUsingChoppingBoard = board.transform;
                    m_Chef.MoveToNextState();
                }
            }
        }

        private ChoppingBoard GetFreeChoppingBoard()
        {
            RaycastHit2D hit = Physics2D.Raycast(m_ChefTransform.value.position, Vector2.zero);
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
