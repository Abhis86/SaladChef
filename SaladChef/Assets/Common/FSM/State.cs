using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public class State : ScriptableObject
    {
        public GameAction[] actions;
        [System.NonSerialized] protected bool mIsInitialized;

        public void DoUpdate(Actor actor, float deltaTime)
        {
            for (int i = 0; i < actions.Length; ++i)
            {
                if (!mIsInitialized)
                    actions[i].DoAction(actor);
                actions[i].DoActionUpdate(actor, deltaTime);
            }

            mIsInitialized = true;
        }

        public void Reset()
        {
            mIsInitialized = false;
        }
    }
}
