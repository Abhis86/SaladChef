using Framework.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/Action/PickSalad")]
    public class PickSalad : GameAction
    {
        public override void DoAction(Actor actor)
        {
            PickSaladPlate(((ChefActor)actor).chef);
        }

        public override void DoActionUpdate(Actor actor, float deltaTime)
        {
        }

        public void PickSaladPlate(Chef chef)
        {
            Plate plateObject = chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>().plate;
            Salad saladInPlate = plateObject.GetComponent<Plate>().pSalad;
            GameObject dummyPlate = Instantiate(chef.pUsingChoppingBoard.GetComponent<ChoppingBoard>().plate.gameObject, chef.pItemsHolder);
            chef.pSaladPickedToDeliver = saladInPlate.Copy();
            saladInPlate.Clear();
            plateObject.itemHolder.transform.ClearChildren();
            dummyPlate.GetComponent<Collider2D>().enabled = false;
        }
    }
}
