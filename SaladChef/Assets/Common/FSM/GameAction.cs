using UnityEngine;
using System.Collections;

namespace Framework.FSM
{
    public abstract class GameAction : ScriptableObject
    {
        public abstract void DoAction(Actor actor);
        public abstract void DoActionUpdate(Actor actor, float deltaTime);
    }
}
