using Framework;
using Framework.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/ChopVegetables")]
    public class DoChopping : ChefAction
    {
        [SerializeField] float m_VegetableChopTime = default;

        public override void DoAction()
        {
            StaticCoroutine.Start(ChopVegetables());
        }

        public override void DoActionUpdate(float deltaTime)
        {

        }

        private IEnumerator ChopVegetables()
        {
            while(m_Chef.GetVegetable() != null)
            {
                m_ChefTransform.value.GetComponent<ChefView>().itemsHolder.GetChild(0).SetParent(m_Chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>().itemHolder);
                yield return new WaitForSeconds(m_VegetableChopTime);
                PutChoppedItemInThePlate();
            }
            m_Chef.MoveToNextState();

        }

        private void PutChoppedItemInThePlate()
        {
            ChoppingBoard board = m_Chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>();
            board.itemHolder.GetChild(0).SetParent(board.plate.itemHolder);
           // m_Chef.pUsigChoppingBoard m_ChefTransform.value.GetChild(0); SetParent */
        }
    }
}
