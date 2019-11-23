using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/TrashCanDetection")]
    public class TrashCanDetection : ChefAction
    {
        public override void DoAction()
        {
           
        }

        public override void DoActionUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(m_Chef.pActionKeyCode))
            {
                if (GetFreeTrashCan() != null)
                {
                    m_Chef.isReadyToThrowSalad.value = true;
                    m_Chef.MoveToNextState();
                }
            }
        }

        private TrashCan GetFreeTrashCan()
        {
            RaycastHit2D hit = Physics2D.Raycast(m_ChefTransform.value.position, Vector2.zero);
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
