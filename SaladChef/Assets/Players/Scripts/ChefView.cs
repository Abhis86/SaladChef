using Framework.FSM;
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
        public ChefActor m_Actor;
        public Chef pChef { get { return m_Actor.chef; } }

        private void Start()
        {
            MovementController movementController = GetComponent<MovementController>();
            movementController.info = pChef.pMovementControlInfo;
            movementController.playerViewSize = GetComponent<Renderer>().bounds.extents;
            movementController.boundary = pChef.pBoundary.value.GetComponent<BoxCollider2D>();
            movementController.DoSetup();
            name = pChef.pName;
        }

        private void Update()
        {
            pChef.pTimeLeft -= Time.deltaTime;
            chefStats.pTimeText = string.Format("{0:0}", pChef.pTimeLeft);
            chefStats.pScoreText = pChef.pScore.ToString();

            pChef.ResetReadyState();
            if (pChef.currentState != null)
                pChef.currentState.DoUpdate(m_Actor, Time.deltaTime);
        }

        public void Pause(bool pause)
        {
            enabled = !pause;
            GetComponent<MovementController>().enabled = !pause;
        }

        public void Reset()
        {
            itemsHolder.ClearChildren();
        }
    }
}
