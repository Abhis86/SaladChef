﻿using Framework.FSM;
using Framework.Scriptables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Players/ Player")]
    public class Chef : ScriptableObject
    {
        [SerializeField] private string m_UserName = default;
        [SerializeField] private MovementControlInfo m_MovementControlInfo = default;
        [SerializeField] private TransformProperty m_MovementBoundary = default;
        [SerializeField] private TransformProperty m_ItemsHolder = default;
        [SerializeField] private KeyCode m_ActionKeyCode = default;
        [SerializeField] private State m_StartState = default;
        [SerializeField] private FSM m_FSM = default;
        [SerializeField] private IntProperty m_CollectedVegetablesCount = default;
        [SerializeField] private float m_DefaultTime = 120;

        public BoolProperty isReadyToChopVegetables = default;
        public BoolProperty isReadyToCollectVegetables = default;
        public BoolProperty isReadyToPickSalad = default;
        public BoolProperty isReadyToThrowSalad = default;
        public BoolProperty isReadyToDeliverSalad = default;
        public BoolProperty isDeliveredCorrectSaladCombination = default;

        public MovementControlInfo pMovementControlInfo { get => m_MovementControlInfo; }
        public string pName { get => m_UserName; }
        public TransformProperty pBoundary { get => m_MovementBoundary; }
        public KeyCode pActionKeyCode { get => m_ActionKeyCode; }

        [NonSerialized] public GameObject selectedVegetable = default;
        [NonSerialized] protected Stack<Vegetable> mPickedVegetables = new Stack<Vegetable>();
        /*[NonSerialized]*/
        public State currentState;
        public Transform pUsingChoppingBoard { get; set; }
        public Transform pItemsHolder { get => m_ItemsHolder.value; }
        public GameObject pSelectedCustomeToDeliverSalad { get; set; }
        public float pTimeLeft { get; set; }
        public int pScore { get; set; }

        [NonSerialized] public Salad pSaladPickedToDeliver = new Salad();

        private void OnEnable()
        {
            currentState = m_StartState;
            pTimeLeft = m_DefaultTime;
            pScore = 0;
        }

        public void ResetReadyState()
        {
            isReadyToChopVegetables.value = false;
            isReadyToCollectVegetables.value = false;
            isReadyToPickSalad.value = false;
            isReadyToThrowSalad.value = false;
            isReadyToDeliverSalad.value = false;
        }

        public void MoveToNextState()
        {
            State nextState = m_FSM.GetNextState(currentState);
            if (nextState != currentState)
            {
                currentState = nextState;
                currentState.Reset();
            }
        }

        private void CollectVegetable(Vegetable vegetable)
        {
            mPickedVegetables.Push(vegetable);
            m_CollectedVegetablesCount.value++;
        }

        public Vegetable GetVegetable()
        {
            if (mPickedVegetables.Count > 0)
            {
                m_CollectedVegetablesCount.value--;
                return mPickedVegetables.Pop();
            }

            return null;
        }

        public void CollectVegetable()
        {
            GameObject vegetable = Instantiate(selectedVegetable, m_ItemsHolder.value);
            CollectVegetable(vegetable.GetComponent<VegetableView>().vegetable);
            vegetable.GetComponent<Collider2D>().enabled = false;
        }

        public void Reset()
        {
            currentState = m_StartState;
            pTimeLeft = m_DefaultTime;
            pScore = 0;
            m_ItemsHolder.value.ClearChildren();
            ResetReadyState();
        }
    }
}
