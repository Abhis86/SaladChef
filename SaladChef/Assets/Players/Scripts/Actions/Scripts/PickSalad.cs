using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/PickSalad")]
    public class PickSalad : ChefAction
    {
        public override void DoAction()
        {
            PickSaladPlate();
        }

        public override void DoActionUpdate(float deltaTime)
        {
        }

        public void PickSaladPlate()
        {
            Plate plateObject = m_Chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>().plate;
            GameObject dummyPlate = Instantiate(m_Chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>().plate.gameObject, m_Chef.pItemsHolder);
            plateObject.itemHolder.transform.ClearChildren();
            dummyPlate.GetComponent<Collider2D>().enabled = false;
        }
    }
}
