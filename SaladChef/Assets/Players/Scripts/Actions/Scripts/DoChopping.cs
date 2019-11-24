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
            Vegetable vegetable = m_Chef.GetVegetable();
            while (vegetable != null)
            {
                m_Chef.pSalad.AddVegetable(vegetable);
                m_ChefTransform.value.GetComponent<ChefView>().itemsHolder.GetChild(0).SetParent(m_Chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>().itemHolder);
                m_Chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>().itemHolder.GetComponent<TransformLayout>().ForcedUpdate();
                yield return new WaitForSeconds(m_VegetableChopTime);
                PutChoppedItemInThePlate();
                vegetable = m_Chef.GetVegetable();
            }
            m_Chef.MoveToNextState();

        }

        private void PutChoppedItemInThePlate()
        {
            ChoppingBoard board = m_Chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>();
            board.itemHolder.GetChild(0).SetParent(board.plate.itemHolder);
        }
    }
}
