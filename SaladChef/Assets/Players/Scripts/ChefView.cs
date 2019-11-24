using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [RequireComponent(typeof(MovementController))]
    public class ChefView : MonoBehaviour
    {
        public ChefStats chefStats;
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
            chef.pTimeLeft -= Time.deltaTime;
            chefStats.pTimeText = string.Format("{0:0}", chef.pTimeLeft);
            chefStats.pScoreText = chef.pScore.ToString();

            chef.ResetReadyState();
            if (chef.currentState != null)
                chef.currentState.DoUpdate(Time.deltaTime);
        }
    }
}
