using UnityEngine;
using System.Collections;

namespace Framework.FSM
{
    public abstract class GameAction : ScriptableObject
    {
        public abstract void DoAction();
        public abstract void DoActionUpdate(float deltaTime);
    }
}
