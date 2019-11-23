using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [RequireComponent(typeof(MovementController))]
    public class ChefView : MonoBehaviour
    {
        public Transform itemsHolder;
        public Chef chef;
        private GameObject mCurrentSelectedVegetable;

        private void Start()
        {
            MovementController movementController = GetComponent<MovementController>();
            movementController.info = chef.pMovementControlInfo;
            movementController.playerViewSize = GetComponent<Renderer>().bounds.extents;
            movementController.boundary = chef.pBoundary.value.GetComponent<BoxCollider2D>();
            movementController.DoSetup();
            name = chef.pName;
        }

        private void Update()
        {
            chef.ResetReadyState();
            if (chef.currentState != null)
                chef.currentState.DoUpdate(Time.deltaTime);
        }

       /* private void OnTriggerEnter2D(Collider2D collision)
        {
            IInteractable interactable = collision.GetComponent<IInteractable>();
            if (interactable is VegetableView)
            {
                chef.isReadyToCollectVegetables.value = true;
                mCurrentSelectedVegetable = collision.gameObject;
                chef.MoveToNextState();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            IInteractable interactable = collision.GetComponent<IInteractable>();
            if (interactable is VegetableView)
            {
                chef.isReadyToCollectVegetables.value = false;
                mCurrentSelectedVegetable = null;
                chef.MoveToNextState();
            }
        }*/

       /* public void CollectVegetable()
        {
            GameObject vegetable = Instantiate(mCurrentSelectedVegetable, itemsHolder);
            chef.CollectVegetable(vegetable.GetComponent<VegetableView>().vegetable);
            vegetable.GetComponent<Collider2D>().enabled = false;
            Debug.Log("Collected Vegetable  "+ mCurrentSelectedVegetable.name);

        }*/
    }
}
