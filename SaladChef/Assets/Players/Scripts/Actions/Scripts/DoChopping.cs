using Framework;
using Framework.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/ChopVegetables")]
    public class DoChopping : GameAction
    {
        [SerializeField] float m_VegetableChopTime = default;

        public override void DoAction(Actor actor)
        {
            StaticCoroutine.Start(ChopVegetables(((ChefActor)actor).chef, ((ChefActor)actor).chefTransform.value));
        }

        public override void DoActionUpdate(Actor actor, float deltaTime)
        {

        }

        private IEnumerator ChopVegetables(Chef chef, Transform chefTransform)
        {
            Vegetable vegetable = chef.GetVegetable();
            while (vegetable != null)
            {
                chef.pSalad.AddVegetable(vegetable);
                chefTransform.GetComponent<ChefView>().itemsHolder.GetChild(0).SetParent(chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>().itemHolder);
                chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>().itemHolder.GetComponent<TransformLayout>().ForcedUpdate();
                yield return new WaitForSeconds(m_VegetableChopTime);
                PutChoppedItemInThePlate(chef);
                vegetable = chef.GetVegetable();
            }
            chef.MoveToNextState();

        }

        private void PutChoppedItemInThePlate(Chef chef)
        {
            ChoppingBoard board = chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>();
            board.itemHolder.GetChild(0).SetParent(board.plate.itemHolder);
        }
    }
}
