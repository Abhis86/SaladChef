using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/PlateDetection")]
    public class PlateDetection : ChefAction
    {
        public override void DoAction()
        {
           
        }

        public override void DoActionUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(m_Chef.pActionKeyCode))
            {
                if (GetFreePlate() != null)
                {
                    m_Chef.isReadyToPickSalad.value = true;
                    m_Chef.MoveToNextState();
                }
            }
        }

        private Plate GetFreePlate()
        {
            RaycastHit2D hit = Physics2D.Raycast(m_ChefTransform.value.position, Vector2.zero);
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
