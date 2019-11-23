using System;
using UnityEngine;

namespace Framework.FSM
{
    [Serializable]
    public class TransitionStateMap
    {
        [SerializeField] private State m_State = default;
        [SerializeField] private Condition[] m_Conditions = default;

        public State pState { get => m_State; }

        public bool Satisfy()
        {
            for (int i = 0; i < m_Conditions.Length; ++i)
            {
                if (!m_Conditions[i].Satisfy())
                    return false;
            }

            return true;
        }
    }

    [Serializable]
    public class StateToStatesTranstionMap
    {
        [SerializeField] private State fromState = default;
        [SerializeField] private TransitionStateMap[] m_ToStates = default;

        public State pFromState { get => fromState; }
        public TransitionStateMap[] ToStates { get => m_ToStates;}
    }

    [CreateAssetMenu(menuName = "FSM/StateMachine")]
    public class FSM : ScriptableObject
    {
        [SerializeField] private StateToStatesTranstionMap[] m_States = default;

        public State GetNextState(State state)
        {
            StateToStatesTranstionMap stateToStatesTranstionMap = Array.Find(m_States, ele => ele.pFromState == state);
            for (int i = 0; i < stateToStatesTranstionMap.ToStates.Length; ++i)
            {
                if (stateToStatesTranstionMap.ToStates[i].Satisfy())
                    return stateToStatesTranstionMap.ToStates[i].pState;
            }

            return state;
        }
    }
}
