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

        private IEnumerator mSpeedUpCoroutine;

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
            if (pChef.pTimeLeft > 0)
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
            if (mSpeedUpCoroutine != null)
                StopCoroutine(mSpeedUpCoroutine);

            GetComponent<MovementController>().info.speedMultiplier = 1;
            itemsHolder.ClearChildren();
        }

        private void AddScore(int score)
        {
            pChef.pScore += score;
        }

        private void AddTime(int time)
        {
            pChef.pTimeLeft += time;
        }

        private void SpeedUp(float speedUpTime)
        {
            Debug.Log("SpeedUp");
            mSpeedUpCoroutine = IncreaseSpeedForTime(speedUpTime);
            StartCoroutine(mSpeedUpCoroutine);
        }

        IEnumerator IncreaseSpeedForTime(float time)
        {
            MovementController controller = GetComponent<MovementController>();
            controller.info.speedMultiplier = 2;
            yield return new WaitForSeconds(time);
            controller.info.speedMultiplier = 1;
        }
    }
}
